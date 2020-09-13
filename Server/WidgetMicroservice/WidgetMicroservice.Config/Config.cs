using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WidgetMicroservice.Config
{
     public class Config : IConfig
     {
          private readonly IConfigurationRoot _configuration;

          public static IConfigurationBuilder GetBuilder(string path)
          {
               return new ConfigurationBuilder()
                   .SetBasePath(path)
                   .AddJsonFile("appsettings.json");
          }

          private IConfigurationRoot GetConfigRoot(string path)
          {
               return new ConfigurationBuilder()
                   .SetBasePath(path)
                   .AddJsonFile("appsettings.json").Build();
          }

          public Config()
          {
               _configuration = GetConfigRoot(Directory.GetCurrentDirectory());
          }

          public string ConnectionString => _configuration["ConnectionStrings:DefaultConnection"];
     }
}
