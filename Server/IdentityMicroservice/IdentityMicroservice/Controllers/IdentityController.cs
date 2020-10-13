using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityMicroservice.DataPresentation.Models;
using IdentityMicroservice.Services.Interfaces;
using IdentityMicroservice.TokenManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMicroservice.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
          private readonly IUserService _userService;

          public IdentityController(IUserService userService)
          {
               _userService = userService;
          }

          [HttpPost]
          public async Task<IActionResult> RegisterUser([FromBody] RegisterModel value)
          {
               var usr = await _userService.Register(new User 
               { 
                    Name = value.Name,
                    Login = value.Login,
                    Password = value.Password
               });

               if (usr != null)
               {
                    return Ok();
               }

               return BadRequest();
          }

          [HttpPost("login")]
          public async Task<IActionResult> Login([FromBody] LoginModel value)
          {
               var user = await _userService.TryAuthenticate(value.Login, value.Password);

               if (user == null) return Unauthorized();

               return Ok(user);
          }

          [HttpPost("refresh")]
          public async Task<IActionResult> RefreshToken([FromBody] TokenModel value)
          {
               var user = await _userService.RefreshToken(value.AccessToken, value.RefreshToken);

               if (user == null) return Unauthorized();

               return Ok(user);
          }
     }
}
