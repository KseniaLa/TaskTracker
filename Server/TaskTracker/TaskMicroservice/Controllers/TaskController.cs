using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Authorization;
using Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMicroservice.Services.Interfaces;
using TaskModel =  TaskMicroservice.DataPresentation.Models.Task;


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
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
          [HttpGet]
          public async Task<IActionResult> GetTasks()
          {
               var tasks = await _taskService.GetTasks();
               return Ok(tasks);
          }

          // POST api/task/add
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Administrator)]
          [HttpPost(Constants.ADD_ITEM)]
          public async Task<IActionResult> AddTask([FromBody]TaskModel value)
          {
               await _taskService.AddTask(value);

               return Ok();
          }

          // POST api/task/edit
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Administrator)]
          [HttpPost(Constants.EDIT_ITEM)]
          public async Task<IActionResult> EditTask([FromBody]TaskModel value)
          {
               await _taskService.UpdateTask(value);

               return Ok();
          }

          // DELETE api/task/delete/5
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Administrator)]
          [HttpDelete(Constants.DELETE_ITEM)]
          public async Task<IActionResult> DeleteTask(int id)
          {
               await _taskService.DeleteTask(id);

               return Ok();
          }
     }
}
