using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMicroservice.DataAccess.Repositories
{
     public interface IGenericRepository<T> where T : class
     {
          Task Add(T item);

          IQueryable<T> GetAll();

          void Delete(int id);

          void Dispose();

          Task<T> GetItem(int id);

          void Update(T item);
     }
}
