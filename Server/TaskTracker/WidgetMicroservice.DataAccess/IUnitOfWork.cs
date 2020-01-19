using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WidgetMicroservice.DataAccess.Repositories;

namespace WidgetMicroservice.DataAccess
{
     public interface IUnitOfWork
     {
          IGenericRepository<Entities.Widget> Widgets { get; }

          Task Save();
     }
}
