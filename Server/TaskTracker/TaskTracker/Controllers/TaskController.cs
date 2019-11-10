﻿using System;
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
          public IActionResult GetTasks()
          {
               return Ok(new { tasks = Data.Tasks });
          }

          // POST api/task/add
          [HttpPost("add")]
          public IActionResult SaveTask([FromBody]Models.Task value)
          {
               Data.Tasks.Add(value);
               return Ok();
          }

          // DELETE api/task/delete/5
          [HttpDelete("delete/{id}")]
          public void DeleteTask(int id)
          {
               Data.Tasks = Data.Tasks.Where(t => t.Id != id).ToList();
          }
     }
}
