using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Services.Interfaces
{
     public interface ITaskService
     {
          Task AddTask(DataPresentation.Models.Task task);

          Task UpdateTask(DataPresentation.Models.Task task);

          Task DeleteTask(int id);

          Task<List<DataPresentation.Models.Task>> GetTasks();
     }
}
