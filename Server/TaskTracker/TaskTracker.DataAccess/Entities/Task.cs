using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskTracker.DataAccess.Entities
{
     public class Task : Entity
     {
          [Required]
          [MaxLength(50)]
          public string Title { get; set; }

          [Required]
          [MaxLength(100)]
          public string Description { get; set; }

          [Required]
          public int Priority { get; set; }

          [Required]
          public int State { get; set; }

          [Required]
          public DateTime DateTime { get; set; }
     }
}
