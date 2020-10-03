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
          private readonly IJwtBuilder _jwtBuilder;

          public IdentityController(IUserService userService, IJwtBuilder jwtBuilder)
          {
               _userService = userService;
               _jwtBuilder = jwtBuilder;
          }

          [HttpPost]
          public void RegisterUser([FromBody] RegisterModel value)
          {

          }

          [HttpPost("login")]
          public async Task<IActionResult> Login([FromBody] LoginModel value)
          {
               var user = await _userService.TryAuthenticate(value.Login, value.Password);

               if (user == null) return BadRequest();

               var token = _jwtBuilder.GetToken(user);

               return Ok(new { token, name = user.Name, login = user.Login, isAdmin = user.IsAdmin });
          }
    }
}
