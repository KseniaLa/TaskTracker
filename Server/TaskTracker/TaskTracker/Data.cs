using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Models;

namespace TaskTracker
{
     public static class Data
     {
          public static List<Task> Tasks = new List<Task>
          {
               new Task { Id = 1, Title = "hello", Priority = 1, State = 0},
               new Task { Id = 2, Title = "qwerty", Priority = 1, State = 1},
               new Task { Id = 3, Title = "good", Priority = 1, State = 2},
               new Task { Id = 4, Title = "fire", Priority = 3, State = 2},
          };

          public static List<Widget> Widgets = new List<Widget>
          {
               new Widget {Id = 1, Title = "test1", Priorities = new int[] {0, 1, 2, 3}, States = new int[] {0, 1, 2 }, BorderColor = "#ff0000", ChartType = 1, ColorScheme = 1 },
               new Widget {Id = 2, Title = "test2", Priorities = new int[] {1}, States = new int[] {0, 1, 2 }, BorderColor = "#00ff00", ChartType = 1, ColorScheme = 1 },
               new Widget {Id = 3, Title = "test3", Priorities = new int[] {3}, States = new int[] {0, 1, 2 }, BorderColor = "#0000ff", ChartType = 1, ColorScheme = 1 }
          };
     }
}
