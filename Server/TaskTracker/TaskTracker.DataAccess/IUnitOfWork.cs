using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DataAccess.Repositories;

namespace TaskTracker.DataAccess
{
     public interface IUnitOfWork
     {
          IGenericRepository<Entities.Task> Tasks { get; }

          IGenericRepository<Entities.Widget> Widgets { get; }

          Task Save();
     }
}
