using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.DataPresentation.Models
{
     public class RegisterModel
     {
          public string Name { get; set; }
          public string Login { get; set; }
          public string Password { get; set; }
     }
}
