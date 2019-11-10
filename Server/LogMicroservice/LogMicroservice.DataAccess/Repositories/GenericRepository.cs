using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogMicroservice.DataAccess.Repositories
{
     public class GenericRepository<T> : IGenericRepository<T> where T : class
     {
          private readonly DbSet<T> _dbSet;

          public GenericRepository(TaskTrackerContext context)
          {
               _dbSet = context.Set<T>();
          }

          public async Task Add(T item)
          {
               await _dbSet.AddAsync(item);
          }

          public void Dispose()
          {
               throw new NotImplementedException();
          }
     }
}
