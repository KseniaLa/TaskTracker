using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
     [Route("api/widget")]
     public class WidgetController : Controller
     {
          // GET: api/widget
          [HttpGet]
          public IActionResult GetWidgets()
          {
               return Ok(new { widgets = Data.Widgets });
          }

          // POST api/widget/add
          [HttpPost("add")]
          public IActionResult AddWidget([FromBody]Widget value)
          {
               Data.Widgets.Add(value);
               return Ok();
          }

          // DELETE api/widget/delete/5
          [HttpDelete("delete/{id}")]
          public void DeleteWWidget(int id)
          {
               Data.Widgets = Data.Widgets.Where(t => t.Id != id).ToList();
          }
     }
}
