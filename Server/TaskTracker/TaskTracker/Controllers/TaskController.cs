using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
     [Route("api/task")]
     public class TaskController : Controller
     {
          // GET: api/task
          [HttpGet]
          public IActionResult Get()
          {
               return Ok(new { tasks = Data.Tasks });
          }

          // POST api/<controller>
          [HttpPost("add")]
          public IActionResult Post([FromBody]Models.Task value)
          {
               Data.Tasks.Add(value);
               return Ok();
          }

          // DELETE api/<controller>/5
          [HttpDelete("delete/{id}")]
          public void Delete(int id)
          {
               Data.Tasks = Data.Tasks.Where(t => t.Id != id).ToList();
          }

          [HttpGet("widgets")]
          public IActionResult GetW()
          {
               return Ok(new { widgets = Data.Widgets });
          }

          // POST api/<controller>
          [HttpPost("add/widget")]
          public IActionResult PostW([FromBody]Widget value)
          {
               Data.Widgets.Add(value);
               return Ok();
          }

          // DELETE api/<controller>/5
          [HttpDelete("delete/widget/{id}")]
          public void DeleteW(int id)
          {
               Data.Widgets = Data.Widgets.Where(t => t.Id != id).ToList();
          }
     }
}
