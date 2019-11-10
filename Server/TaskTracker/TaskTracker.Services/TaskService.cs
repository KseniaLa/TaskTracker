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
                    DateTime = DateTime.Now ///////////////////////////////
               };

               await Db.Tasks.Add(dbTask);
               await Db.Save();
          }

          public Task DeleteTask(int id)
          {
               throw new NotImplementedException();
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

          public Task UpdateTask(DataPresentation.Models.Task task)
          {
               throw new NotImplementedException();
          }
     }
}
