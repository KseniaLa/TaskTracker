using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WidgetMicroservice.DataAccess.Entities
{
     public class Widget : Entity
     {
          private int[] _priorities;
          private int[] _states;

          [Required]
          [MaxLength(50)]
          public string Title { get; set; }

          [Required]
          public string Priorities { get; set; }
          [NotMapped]
          public int[] PrioritiesData
          {
               get
               {
                    return Array.ConvertAll(Priorities.Split(';'), int.Parse);
               }
               set
               {
                    _priorities = value;
                    Priorities = string.Join(";", _priorities.Select(p => p.ToString()).ToArray());
               }
          }

          [Required]
          public string States { get; set; }
          [NotMapped]
          public int[] StatesData
          {
               get
               {
                    return Array.ConvertAll(States.Split(';'), int.Parse);
               }
               set
               {
                    _states = value;
                    States = string.Join(";", _states.Select(p => p.ToString()).ToArray());
               }
          }

          [Required]
          public int ChartType { get; set; }

          [Required]
          public int ColorScheme { get; set; }

          [Required]
          [MaxLength(30)]
          public string BorderColor { get; set; }
     }
}
