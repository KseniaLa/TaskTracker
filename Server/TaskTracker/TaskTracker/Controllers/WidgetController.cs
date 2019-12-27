﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.DataPresentation.Models;
using TaskTracker.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
     [Route("api/widget")]
     public class WidgetController : Controller
     {
          private readonly IWidgetService _widgetService;

          public WidgetController(IWidgetService widgetService)
          {
               _widgetService = widgetService;
          }

          // GET: api/widget
          [HttpGet]
          public async Task<IActionResult> GetWidgets()
          {
               try
               {
                    var widgets = await _widgetService.GetWidgets();
                    return Ok(widgets);
               }
               catch
               {
                    return BadRequest();
               }
          }

          // POST api/widget/add
          [HttpPost("add")]
          public async Task<IActionResult> AddWidget([FromBody]Widget value)
          {
               try
               {
                    await _widgetService.AddWidget(value);
               }
               catch
               {
                    return BadRequest();
               }

               return Ok();
          }

          // DELETE api/widget/delete/5
          [HttpDelete("delete/{id}")]
          public async Task<IActionResult> DeleteWWidget(int id)
          {
               try
               {
                    await _widgetService.DeleteWidget(id);
               }
               catch
               {
                    return BadRequest();
               }

               return Ok();
          }
     }
}
