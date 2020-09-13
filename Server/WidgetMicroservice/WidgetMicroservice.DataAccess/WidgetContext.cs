using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WidgetMicroservice.DataAccess.Entities;

namespace WidgetMicroservice.DataAccess
{
     public class WidgetContext : DbContext, IWidgetContext
     {
          private readonly IConfig _config;

          public WidgetContext()
          {
          }

          public WidgetContext(DbContextOptions options, IConfig config) : base(options)
          {
               _config = config;
          }

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
