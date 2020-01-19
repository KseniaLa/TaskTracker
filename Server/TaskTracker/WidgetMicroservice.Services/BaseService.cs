using System;
using System.Collections.Generic;
using System.Text;
using WidgetMicroservice.DataAccess;

namespace WidgetMicroservice.Services
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
