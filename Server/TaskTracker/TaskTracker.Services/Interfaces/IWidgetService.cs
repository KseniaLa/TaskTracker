using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Services.Interfaces
{
     public interface IWidgetService
     {
          Task AddWidget(DataPresentation.Models.Widget widget);

          Task DeleteWidget(int id);

          Task<List<DataPresentation.Models.Widget>> GetWidgets();
     }
}
