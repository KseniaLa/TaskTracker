using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WidgetMicroservice.DataAccess.Entities;
using WidgetMicroservice.DataAccess.Repositories;

namespace WidgetMicroservice.DataAccess
{
     public interface IUnitOfWork
     {
          IGenericRepository<Widget> Widgets { get; }

          Task Save();
     }
}
