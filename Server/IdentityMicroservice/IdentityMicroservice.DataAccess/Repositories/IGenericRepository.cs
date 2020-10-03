using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMicroservice.DataAccess.Repositories
{
     public interface IGenericRepository<T> where T : class
     {
          Task Add(T item);

          IQueryable<T> GetAll();

          IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

          void Delete(int id);

          void Dispose();

          Task<T> GetItem(int id);

          void Update(T item);
     }
}
