using IdentityMicroservice.DataPresentation.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityMicroservice.TokenManagement
{
     public class JwtBuilder : IJwtBuilder
     {
          private readonly JwtOptions _options;

          public JwtBuilder(IOptions<JwtOptions> options)
          {
               _options = options.Value;
          }

          public string GetToken(User user)
          {
               var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
               var signingCredentials =
                   new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

               var claims = CreateClaims(user);

               var expirationDate = DateTime.Now.AddMinutes(_options.ExpiryMinutes);
               var jwt = new JwtSecurityToken
                 (claims: claims, signingCredentials: signingCredentials, expires: expirationDate);
               var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

               return encodedJwt;
          }

          private static IEnumerable<Claim> CreateClaims(User user)
          {
               return new[]
               {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Login", user.Login),
                    new Claim("Role", user.IsAdmin ? Roles.Administrator : Roles.User)
               };
          }

          public Guid ValidateToken(string token)
          {
               var principal = GetPrincipal(token);
               if (principal == null)
               {
                    return Guid.Empty;
               }

               ClaimsIdentity identity;
               try
               {
                    identity = (ClaimsIdentity)principal.Identity;
               }
               catch (NullReferenceException)
               {
                    return Guid.Empty;
               }
               var userIdClaim = identity.FindFirst("userId");
               var userId = new Guid(userIdClaim.Value);
               return userId;
          }

          private ClaimsPrincipal GetPrincipal(string token)
          {
               try
               {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                    if (jwtToken == null)
                    {
                         return null;
                    }
                    var key = Encoding.UTF8.GetBytes(_options.Secret);
                    var parameters = new TokenValidationParameters()
                    {
                         RequireExpirationTime = true,
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                    IdentityModelEventSource.ShowPII = true;
                    SecurityToken securityToken;
                    ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                            parameters, out securityToken);
                    return principal;
               }
               catch (Exception)
               {
                    return null;
               }
          }
     }
}
