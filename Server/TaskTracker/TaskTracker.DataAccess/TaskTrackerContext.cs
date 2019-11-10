using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Config;
using TaskTracker.DataAccess.Entities;

namespace TaskTracker.DataAccess
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

          public DbSet<Task> Tasks { get; set; }
          public DbSet<Widget> Widgets { get; set; }

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
