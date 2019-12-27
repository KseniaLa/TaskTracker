using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Constants;
using LogMicroservice.DataPresentation.Models;
using LogMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogMicroservice.Controllers
{
     [Route("api/log")]
     public class ClientLogController : Controller
     {
          private readonly IClientLogService _logService;

          public ClientLogController(IClientLogService logService)
          {
               _logService = logService;
          }

          // POST api/log/client
          [HttpPost("client")]
          public async Task<IActionResult> SaveClientLogs([FromBody]ClientLogModel logs)
          {
               if (logs == null || logs.Logs == null)
               {
                    return Ok();
               }

               try
               {
                    await _logService.AddLogs(logs.Logs);
               }
               catch
               {
                    return BadRequest();
               }

               return Ok();
          }
     }
}
