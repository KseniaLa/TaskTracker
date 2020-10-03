using IdentityMicroservice.DataPresentation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.TokenManagement
{
     public interface IJwtBuilder
     {
          string GetToken(User user);
          Guid ValidateToken(string token);
     }
}
