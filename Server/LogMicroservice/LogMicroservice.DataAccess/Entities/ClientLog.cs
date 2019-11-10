using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogMicroservice.DataAccess.Entities
{
     public class ClientLog : Entity
     {
          [Required]
          [MaxLength(50)]
          public string Level { get; set; }

          [Required]
          [MaxLength(100)]
          public string Message { get; set; }
          
          [Required]
          [MaxLength(50)]
          public string Timestamp { get; set; }
     }
}
