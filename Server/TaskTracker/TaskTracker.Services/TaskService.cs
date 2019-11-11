using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DataAccess;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
     public class TaskService : BaseService, ITaskService, IScopedService
     {
          public TaskService(IUnitOfWork unitOfWork) : base(unitOfWork)
          {

          }

          public async Task AddTask(DataPresentation.Models.Task task)
          {
               var dbTask = new DataAccess.Entities.Task
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

          public async Task<List<DataPresentation.Models.Task>> GetTasks()
          {
               var rawTasks = await Db.Tasks.GetAll().ToListAsync();

               return rawTasks.Select(t => new DataPresentation.Models.Task
               {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    State = t.State,
                    Priority = t.Priority,
                    Date = t.DateTime
               }).ToList();
          }

          public async Task UpdateTask(DataPresentation.Models.Task task)
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
