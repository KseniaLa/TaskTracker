﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DashboardMicroservice
{
     public class Program
     {
          public static void Main(string[] args)
          {
               CreateHostBuilder(args).Build().Run();
          }

          public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration((hostingContext, config) =>
              {
                   config
                     .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                     .AddJsonFile("appsettings.json", true, true)
                     .AddJsonFile($"configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                     .AddEnvironmentVariables();
              })
              .ConfigureWebHostDefaults(webBuilder =>
              {
                   webBuilder.UseStartup<Startup>();
              });
     }
}
