using LogMicroservice.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.Services
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
