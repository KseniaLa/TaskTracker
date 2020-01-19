using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMicroservice.DataAccess.Entities;

namespace TaskMicroservice.DataAccess
{
     public interface ITaskTrackerContext
     {
          DbSet<Task> Tasks { get; set; }
     }
}
