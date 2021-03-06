﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.DataPresentation.Models
{
     public class User
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Login { get; set; }
          public string Password { get; set; }
          public bool IsAdmin { get; set; }
          public string AccessToken { get; set; }
          public string RefreshToken { get; set; }
     }
}
