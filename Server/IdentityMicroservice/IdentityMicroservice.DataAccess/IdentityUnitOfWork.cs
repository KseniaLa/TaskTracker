using IdentityMicroservice.DataAccess.Entities;
using IdentityMicroservice.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMicroservice.DataAccess
{
     public class IdentityUnitOfWork : IUnitOfWork
     {
          private readonly IdentityContext _db;
          private readonly IServiceProvider _serviceProvider;

          public IGenericRepository<User> Users => GetGenericRepository<User>();

          public IdentityUnitOfWork(IdentityContext context, IServiceProvider serviceProvider)
          {
               _db = context;
               _serviceProvider = serviceProvider;
          }

          private IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class
          {
               return (IGenericRepository<TEntity>)_serviceProvider.GetService(typeof(IGenericRepository<TEntity>));
          }

          public async Task Save()
          {
               await _db.SaveChangesAsync();
          }

          private bool _disposed;

          public virtual void Dispose(bool disposing)
          {
               if (!_disposed)
               {
                    if (disposing)
                    {
                         _db.Dispose();
                    }
                    _disposed = true;
               }
          }

          public void Dispose()
          {
               Dispose(true);
               GC.SuppressFinalize(this);
          }
     }
}
