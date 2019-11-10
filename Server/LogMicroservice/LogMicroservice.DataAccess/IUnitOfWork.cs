using LogMicroservice.DataAccess.Entities;
using LogMicroservice.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogMicroservice.DataAccess
{
     public interface IUnitOfWork
     {
          IGenericRepository<ClientLog> ClientLogs { get; }

          Task Save();
     }
}
