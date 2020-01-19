using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskMicroservice.DataAccess.Repositories;

namespace TaskMicroservice.DataAccess
{
     public interface IUnitOfWork
     {
          IGenericRepository<Entities.Task> Tasks { get; }

          Task Save();
     }
}
