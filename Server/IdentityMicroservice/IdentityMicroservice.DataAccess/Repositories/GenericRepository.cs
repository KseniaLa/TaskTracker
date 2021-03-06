﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMicroservice.DataAccess.Repositories
{
     public class GenericRepository<T> : IGenericRepository<T> where T : class
     {
          private readonly DbSet<T> _dbSet;

          public GenericRepository(IdentityContext context)
          {
               _dbSet = context.Set<T>();
          }

          public async Task Add(T item)
          {
               await _dbSet.AddAsync(item);
          }

          public IQueryable<T> GetAll()
          {
               return _dbSet;
          }

          public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
          {
               IQueryable<T> query = _dbSet.Where(predicate);
               return query;
          }

          public void Delete(int id)
          {
               T item = _dbSet.Find(id);
               if (item != null)
               {
                    _dbSet.Remove(item);
               }
          }

          public void Dispose()
          {
               throw new NotImplementedException();
          }

          public async Task<T> GetItem(int id)
          {
               return await _dbSet.FindAsync(id);
          }

          public void Update(T item)
          {
               _dbSet.Update(item);
          }
     }
}
