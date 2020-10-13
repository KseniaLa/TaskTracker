using IdentityMicroservice.DataPresentation.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

          public string GetAccessToken(User user)
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

          public string GenerateRefreshToken()
          {
               var randomNumber = new byte[32];
               using var rng = RandomNumberGenerator.Create();
               rng.GetBytes(randomNumber);
               return Convert.ToBase64String(randomNumber);
          }

          public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
          {
               //!!!
               var tokenValidationParameters = new TokenValidationParameters
               {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
                    ValidateLifetime = false
               };
               var tokenHandler = new JwtSecurityTokenHandler();
               SecurityToken securityToken;
               var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
               var jwtSecurityToken = securityToken as JwtSecurityToken;
               if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");
               return principal;
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
