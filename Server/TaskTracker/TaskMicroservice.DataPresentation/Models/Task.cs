﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMicroservice.DataPresentation.Models
{
     public class Task
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          public int Priority { get; set; }
          public int State { get; set; }
          public DateTime Date { get; set; }
     }
}
