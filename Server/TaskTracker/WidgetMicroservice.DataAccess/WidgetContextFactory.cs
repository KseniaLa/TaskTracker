using Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetMicroservice.DataAccess
{
     public class WidgetContextFactory : IDesignTimeDbContextFactory<WidgetContext>
     {
          public WidgetContext CreateDbContext(string[] args)
          {
               var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
               var basePath = AppContext.BaseDirectory;
               return Create(basePath, environmentName);
          }

          private WidgetContext Create(string basePath, string environmentName)
          {
               var builder = Config.GetBuilder(basePath);

               var config = builder.Build();
               var connectionString = config.GetConnectionString("DefaultConnection");

               if (string.IsNullOrWhiteSpace(connectionString))
               {
                    throw new InvalidOperationException(
                        "Could not find a connection string named '(DefaultConnection)'.");
               }

               return Create(connectionString);
          }

          private WidgetContext Create(string connectionString)
          {
               if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentException(
                        $"{nameof(connectionString)} is null or empty.",
                        nameof(connectionString));

               var optionsBuilder = new DbContextOptionsBuilder();
               optionsBuilder.UseSqlServer(connectionString);
               return new WidgetContext(optionsBuilder.Options, new Config());
          }
     }
}
