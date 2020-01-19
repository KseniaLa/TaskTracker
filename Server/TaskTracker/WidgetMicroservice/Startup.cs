using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Constants;
using Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskTracker.Config;
using TaskTracker.Middleware;
using TaskTracker.Services;
using TaskTracker.Services.Interfaces;
using WidgetMicroservice.DataAccess;
using WidgetMicroservice.DataAccess.Repositories;
using WidgetMicroservice.Services;
using WidgetMicroservice.Services.Interfaces;

namespace WidgetMicroservice
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

               services.AddTransient<IConfig, Config>();
               services.AddTransient<IWidgetContext, WidgetContext>();
               services.AddDbContext<WidgetContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

               services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
               services.AddTransient<IUnitOfWork, WidgetUnitOfWork>();

               services.Scan(scan => scan
                 .FromAssembliesOf(new List<Type> { typeof(IWidgetService), typeof(WidgetService) })
                 .AddClasses(classes => classes.AssignableTo<IScopedService>())
                 .AsImplementedInterfaces()
                 .WithScopedLifetime()
               );

               services.AddMvc(options =>
               {
                    options.UseCentralRoutePrefix(new RouteAttribute(Constants.GLOBAL_PREFIX));
               }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
