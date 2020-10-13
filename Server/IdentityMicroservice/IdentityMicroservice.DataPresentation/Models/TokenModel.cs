using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.DataPresentation.Models
{
     public class TokenModel
     {
          public string AccessToken { get; set; }
          public string RefreshToken { get; set; }
     }
}
