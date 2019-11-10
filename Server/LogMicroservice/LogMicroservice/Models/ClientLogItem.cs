using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogMicroservice.Models
{
     public class ClientLogItem
     {
          public string Level { get; set; }
          public string Message { get; set; }
          public string Timestamp { get; set; }
     }
}
