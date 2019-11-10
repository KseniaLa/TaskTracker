using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.Config
{
     public interface IConfig
     {
          string ConnectionString { get; }
     }
}
