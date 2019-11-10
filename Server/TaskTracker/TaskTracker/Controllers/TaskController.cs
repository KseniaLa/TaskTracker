using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.DataPresentation.Models;
using TaskTracker.Services.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
     [Route("api/task")]
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
               try
               {
                    var tasks = await _taskService.GetTasks();
                    return Ok(new { tasks });
               }
               catch
               {
                    return BadRequest();
               }
          }

          // POST api/task/add
          [HttpPost("add")]
          public async Task<IActionResult> SaveTask([FromBody]DataPresentation.Models.Task value)
          {
               try
               {
                    await _taskService.AddTask(value);
               }
               catch
               {
                    return BadRequest();
               }
               
               return Ok();
          }

          // DELETE api/task/delete/5
          [HttpDelete("delete/{id}")]
          public void DeleteTask(int id)
          {
               //Data.Tasks = Data.Tasks.Where(t => t.Id != id).ToList();
          }
     }
}
