using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
     public class Widget
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public int[] Priorities { get; set; }
          public int[] States { get; set; }
          public int ChartType { get; set; }
          public int ColorScheme { get; set; }
          public string BorderColor { get; set; }
     }
}
