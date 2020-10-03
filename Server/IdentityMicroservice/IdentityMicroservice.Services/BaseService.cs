using IdentityMicroservice.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.Services
{
     public abstract class BaseService
     {
          protected IUnitOfWork Db;

          public BaseService(IUnitOfWork unitOfWork)
          {
               Db = unitOfWork;
          }
     }
}
