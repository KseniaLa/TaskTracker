using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
     public class Startup
     {
          public Startup(IHostingEnvironment env)
          {
               var builder = new ConfigurationBuilder();
               builder.SetBasePath(env.ContentRootPath)  
                      .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();

               Configuration = builder.Build();
          }

          public IConfigurationRoot Configuration { get; }

          // This method gets called by the runtime. Use this method to add services to the container.
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

               services.AddOcelot(Configuration);

               var jwtSection = Configuration.GetSection("Jwt");
               var jwtOptions = jwtSection.Get<JwtOptions>();
               var key = Encoding.UTF8.GetBytes(jwtOptions.Secret);

               services.AddAuthentication(x =>
               {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(x =>
               {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = false,
                         ValidateAudience = false
                    };
               });
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }

               app.UseAuthentication();

               app.UseMvc();

               await app.UseOcelot();
          }
     }
}
