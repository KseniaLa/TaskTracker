using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Config
{
     public interface IConfig
     {
          string ConnectionString { get; }
     }
}
