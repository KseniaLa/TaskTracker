using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskModel = TaskMicroservice.DataPresentation.Models.Task;

namespace TaskMicroservice.Services.Interfaces
{
     public interface ITaskService
     {
          Task AddTask(TaskModel task);

          Task UpdateTask(TaskModel task);

          Task DeleteTask(int id);

          Task<List<TaskModel>> GetTasks();
     }
}
