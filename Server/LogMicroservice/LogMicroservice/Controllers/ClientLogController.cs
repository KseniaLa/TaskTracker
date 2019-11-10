using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogMicroservice.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogMicroservice.Controllers
{
     [Route("api/log")]
     public class ClientLogController : Controller
     {
          // POST api/log/client
          [HttpPost("client")]
          public IActionResult SaveClientLogs([FromBody]ClientLogModel logs)
          {
               return Ok();
          }
     }
}
