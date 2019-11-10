﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
     public class Task
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          public int Priority { get; set; }
          public int State { get; set; }
     }
}
