using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using TaskMicroservice.Services.Interfaces;
using TaskTracker.DataPresentation.Models;
using TaskTracker.Services.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
     [Route(Constants.TASK_ROOT)]
     public class TaskController : Controller
     {
          private readonly ITaskService _taskService;

          public TaskController(ITaskService taskService)
          {
               _taskService = taskService;
          }

          // GET: api/task
          [HttpGet]
          public async Task<IActionResult> GetTasks()
          {
               var tasks = await _taskService.GetTasks();
               return Ok(tasks);
          }

          // POST api/task/add
          [HttpPost(Constants.ADD_ITEM)]
          public async Task<IActionResult> AddTask([FromBody]DataPresentation.Models.Task value)
          {
               await _taskService.AddTask(value);

               return Ok();
          }

          // POST api/task/edit
          [HttpPost(Constants.EDIT_ITEM)]
          public async Task<IActionResult> EditTask([FromBody]DataPresentation.Models.Task value)
          {
               await _taskService.UpdateTask(value);

               return Ok();
          }

          // DELETE api/task/delete/5
          [HttpDelete(Constants.DELETE_ITEM)]
          public async Task<IActionResult> DeleteTask(int id)
          {
               await _taskService.DeleteTask(id);

               return Ok();
          }
     }
}
