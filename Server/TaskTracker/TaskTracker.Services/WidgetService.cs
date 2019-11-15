﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DataAccess;
using TaskTracker.DataPresentation.Models;
using TaskTracker.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskTracker.Services
{
     public class WidgetService : BaseService, IWidgetService, IScopedService
     {
          public WidgetService(IUnitOfWork unitOfWork) : base(unitOfWork)
          {

          }

          public async Task AddWidget(Widget widget)
          {
               var dbWidget = new DataAccess.Entities.Widget
               {
                    Title = widget.Title,
                    StatesData = widget.States,
                    PrioritiesData = widget.Priorities,
                    ChartType = widget.ChartType,
                    ColorScheme = widget.ColorScheme,
                    BorderColor = widget.BorderColor
               };

               await Db.Widgets.Add(dbWidget);
               await Db.Save();
          }

          public async Task DeleteWidget(int id)
          {
               Db.Widgets.Delete(id);
               await Db.Save();
          }

          public async Task<List<Widget>> GetWidgets()
          {
               var rawWidgets = await Db.Widgets.GetAll().ToListAsync();

               return rawWidgets.Select(t => new Widget
               {
                    Id = t.Id,
                    Title = t.Title,
                    States = t.StatesData,
                    Priorities = t.PrioritiesData,
                    BorderColor = t.BorderColor,
                    ChartType = t.ChartType,
                    ColorScheme = t.ColorScheme
               }).ToList();
          }
     }
}