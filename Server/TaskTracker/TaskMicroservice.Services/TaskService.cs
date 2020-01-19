using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMicroservice.Services.Interfaces;
using TaskTracker.DataAccess;
using TaskModel = TaskTracker.DataPresentation.Models.Task;
using TaskDb = TaskTracker.DataAccess.Entities.Task;
using Common.DependencyInjection;

namespace TaskMicroservice.Services
{
     public class TaskService : BaseService, ITaskService, IScopedService
     {
          public TaskService(IUnitOfWork unitOfWork) : base(unitOfWork)
          {

          }

          public async Task AddTask(TaskModel task)
          {
               var dbTask = new TaskDb
               {
                    Title = task.Title,
                    Description = task.Description,
                    State = task.State,
                    Priority = task.Priority,
                    DateTime = task.Date
               };

               await Db.Tasks.Add(dbTask);
               await Db.Save();
          }

          public async Task DeleteTask(int id)
          {
               Db.Tasks.Delete(id);
               await Db.Save();
          }

          public async Task<List<TaskModel>> GetTasks()
          {
               var rawTasks = await Db.Tasks.GetAll().ToListAsync();

               return rawTasks.Select(t => new TaskModel
               {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    State = t.State,
                    Priority = t.Priority,
                    Date = t.DateTime
               }).ToList();
          }

          public async Task UpdateTask(TaskModel task)
          {
               var editTask = await Db.Tasks.GetItem(task.Id);

               if (editTask == null) return;

               editTask.Title = task.Title;
               editTask.Description = task.Description;
               editTask.Priority = task.Priority;
               editTask.State = task.State;
               editTask.DateTime = task.Date;

               Db.Tasks.Update(editTask);
               await Db.Save();
          }
     }
}
