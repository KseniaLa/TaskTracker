using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.DataAccess
{
     public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
     {
          public LogDbContext CreateDbContext(string[] args)
          {
               var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
               var basePath = AppContext.BaseDirectory;
               return Create(basePath, environmentName);
          }

          private LogDbContext Create(string basePath, string environmentName)
          {
               var builder = Config.Config.GetBuilder(basePath);

               var config = builder.Build();
               var connectionString = config.GetConnectionString("DefaultConnection");

               if (string.IsNullOrWhiteSpace(connectionString))
               {
                    throw new InvalidOperationException(
                        "Could not find a connection string named '(DefaultConnection)'.");
               }

               return Create(connectionString);
          }

          private LogDbContext Create(string connectionString)
          {
               if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentException(
                        $"{nameof(connectionString)} is null or empty.",
                        nameof(connectionString));

               var optionsBuilder = new DbContextOptionsBuilder();
               optionsBuilder.UseSqlServer(connectionString);
               return new LogDbContext(optionsBuilder.Options, new Config.Config());
          }
     }
}
