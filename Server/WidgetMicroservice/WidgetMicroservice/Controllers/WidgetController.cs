using Common.Authorization;
using Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WidgetMicroservice.DataPresentation.Models;
using WidgetMicroservice.Services.Interfaces;

namespace WidgetMicroservice.Controllers
{
     [Route(Constants.WIDGET_ROOT)]
     public class WidgetController : Controller
     {
          private readonly IWidgetService _widgetService;

          public WidgetController(IWidgetService widgetService)
          {
               _widgetService = widgetService;
          }

          // GET: api/widget
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
          [HttpGet]
          public async Task<IActionResult> GetWidgets()
          {
               var widgets = await _widgetService.GetWidgets();
               return Ok(widgets);
          }

          // POST api/widget/add
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Administrator)]
          [HttpPost(Constants.ADD_ITEM)]
          public async Task<IActionResult> AddWidget([FromBody]Widget value)
          {
               await _widgetService.AddWidget(value);

               return Ok();
          }

          // DELETE api/widget/delete/5
          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Administrator)]
          [HttpDelete(Constants.DELETE_ITEM)]
          public async Task<IActionResult> DeleteWWidget(int id)
          {
               await _widgetService.DeleteWidget(id);

               return Ok();
          }
     }
}
