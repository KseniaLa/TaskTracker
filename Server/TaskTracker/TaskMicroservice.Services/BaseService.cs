﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskMicroservice.DataAccess;

namespace TaskMicroservice.Services
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
