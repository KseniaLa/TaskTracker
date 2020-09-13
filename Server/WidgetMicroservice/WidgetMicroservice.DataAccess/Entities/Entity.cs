﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetMicroservice.DataAccess.Entities
{
     public abstract class Entity
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
     }
}
