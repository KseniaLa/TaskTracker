﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WidgetMicroservice.DataPresentation.Models;

namespace WidgetMicroservice.Services.Interfaces
{
     public interface IWidgetService
     {
          Task AddWidget(Widget widget);

          Task DeleteWidget(int id);

          Task<List<Widget>> GetWidgets();
     }
}
