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

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               var connectionString = _config.ConnectionString;
               optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
          }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.Entity<Task>().HasData(new Task
               {
                    Id = 1,
                    Title = "Test task",
                    Description = "Test task description",
                    Priority = 0,
                    State = 0,
                    DateTime = DateTime.Now
               },
               new Task
               {
                    Id = 2,
                    Title = "Hello task",
                    Description = "description",
                    Priority = 1,
                    State = 1,
                    DateTime = DateTime.Now
               },
               new Task
               {
                    Id = 3,
                    Title = "Critical task",
                    Description = "task description",
                    Priority = 3,
                    State = 1,
                    DateTime = DateTime.Now
               });
          }
     }
}
