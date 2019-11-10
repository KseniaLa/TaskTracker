using LogMicroservice.Config;
using LogMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.DataAccess
{
     public class TaskTrackerContext : DbContext, ITaskTrackerContext
     {
          private readonly IConfig _config;

          public TaskTrackerContext()
          {
          }

          public TaskTrackerContext(DbContextOptions options, IConfig config) : base(options)
          {
               _config = config;
          }

          public DbSet<ClientLog> ClientLogs { get; set; }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               var connectionString = _config.ConnectionString;
               optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
          }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               
          }
     }
}
