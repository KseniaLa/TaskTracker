using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.DataAccess;

namespace TaskTracker.Services
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
