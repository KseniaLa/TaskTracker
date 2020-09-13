using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WidgetMicroservice.DataAccess.Entities;

namespace WidgetMicroservice.DataAccess
{
     public interface IWidgetContext
     {
          DbSet<Widget> Widgets { get; set; }
     }
}
