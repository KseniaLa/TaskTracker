using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.DataAccess.Entities;

namespace TaskTracker.DataAccess
{
     public interface ITaskTrackerContext
     {
          DbSet<Task> Tasks { get; set; }
     }
}
