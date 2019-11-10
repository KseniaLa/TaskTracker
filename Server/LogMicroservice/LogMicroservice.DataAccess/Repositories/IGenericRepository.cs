using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogMicroservice.DataAccess.Repositories
{
     public interface IGenericRepository<T> where T : class
     {
          Task Add(T item);
     }
}
