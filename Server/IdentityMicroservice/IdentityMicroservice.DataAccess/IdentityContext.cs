using Common.Configuration;
using IdentityMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.DataAccess
{
     public class IdentityContext : DbContext, IIdentityContext
     {
          private readonly IConfig _config;

          public IdentityContext()
          {
          }

          public IdentityContext(DbContextOptions options, IConfig config) : base(options)
          {
               _config = config;
          }

          public DbSet<User> Users { get; set; }

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
