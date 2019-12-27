﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskTracker.Config;
using TaskTracker.DataAccess;
using TaskTracker.DataAccess.Repositories;
using TaskTracker.Middleware;
using TaskTracker.Services;
using TaskTracker.Services.Interfaces;

namespace TaskTracker
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

               services.AddTransient<IConfig, Config.Config>();
               services.AddTransient<ITaskTrackerContext, TaskTrackerContext>();
               services.AddDbContext<TaskTrackerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

               services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
               services.AddTransient<IUnitOfWork, TaskTrackerUnitOfWork>();

               services.Scan(scan => scan
                 .FromAssembliesOf(new List<Type> { typeof(ITaskService), typeof(TaskService) })
                 .AddClasses(classes => classes.AssignableTo<IScopedService>())
                 .AsImplementedInterfaces()
                 .WithScopedLifetime()
               );

               services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IHostingEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }

               app.UseCors(
                    options => options.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()
               );

               app.UseMiddleware<ExceptionMiddleware>();

               app.UseMvc();
          }
     }
}
