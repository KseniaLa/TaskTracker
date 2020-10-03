using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityMicroservice.DataAccess.Entities
{
     public class User : Entity
     {
          [Required]
          [MaxLength(50)]
          public string Name { get; set; }

          [Required]
          [MaxLength(100)]
          public string Login { get; set; }

          [Required]
          [MaxLength(100)]
          public string PasswordHash { get; set; }

          [Required]
          public bool IsAdmin { get; set; }
     }
}
