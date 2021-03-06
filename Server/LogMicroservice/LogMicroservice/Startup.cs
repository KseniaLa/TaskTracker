﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Configuration;
using Common.Constants;
using Common.DependencyInjection;
using Common.Extensions;
using Common.Middleware;
using LogMicroservice.DataAccess;
using LogMicroservice.DataAccess.Repositories;
using LogMicroservice.Services;
using LogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LogMicroservice
{
     public class Startup
     {
          public Startup(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          public IConfiguration Configuration { get; }

          // This method gets called by the runtime. Use this method to add services to the container.
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddCors();

               services.AddTransient<IConfig, Common.Configuration.Config>();
               services.AddTransient<ILogDbContext, LogDbContext>();
               services.AddDbContext<LogDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

               services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
               services.AddTransient<IUnitOfWork, LogDbUnitOfWork>();

               services.Scan(scan => scan
                 .FromAssembliesOf(new List<Type> { typeof(IClientLogService), typeof(ClientLogService) })
                 .AddClasses(classes => classes.AssignableTo<IScopedService>())
                 .AsImplementedInterfaces()
                 .WithScopedLifetime()
               );

               services.AddMvc(options =>
               {
                    options.UseCentralRoutePrefix(new RouteAttribute(Constants.GLOBAL_PREFIX));
               }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }

               app.UseRouting();

               app.UseAuthorization();

               app.UseCors(
                    options => options.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()
               );

               app.UseMiddleware<ExceptionMiddleware>();

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
