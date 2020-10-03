using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.TokenManagement
{
     public class JwtOptions
     {
          public string Secret { get; set; }
          public int ExpiryMinutes { get; set; }
     }
}
