using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DataPresentation.Models;
using Task = System.Threading.Tasks.Task;

namespace WidgetMicroservice.Services.Interfaces
{
     public interface IWidgetService
     {
          Task AddWidget(Widget widget);

          Task DeleteWidget(int id);

          Task<List<Widget>> GetWidgets();
     }
}
