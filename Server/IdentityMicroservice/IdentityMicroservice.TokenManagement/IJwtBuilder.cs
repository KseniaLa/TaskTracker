using IdentityMicroservice.DataPresentation.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentityMicroservice.TokenManagement
{
     public interface IJwtBuilder
     {
          string GetAccessToken(User user);
          Guid ValidateToken(string token);
          string GenerateRefreshToken();
          ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
     }
}
