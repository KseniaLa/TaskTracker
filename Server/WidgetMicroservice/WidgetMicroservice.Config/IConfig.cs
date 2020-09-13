using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetMicroservice.Config
{
     public interface IConfig
     {
          string ConnectionString { get; }
     }
}
