using IdentityMicroservice.DataAccess.Entities;
using IdentityMicroservice.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMicroservice.DataAccess
{
     public interface IUnitOfWork
     {
          IGenericRepository<User> Users { get; }

          Task Save();
     }
}
