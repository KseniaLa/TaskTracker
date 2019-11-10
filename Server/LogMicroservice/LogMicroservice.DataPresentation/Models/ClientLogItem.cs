using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.DataPresentation.Models
{
     public class ClientLogItem
     {
          public string Level { get; set; }
          public string Message { get; set; }
          public string Timestamp { get; set; }
     }
}
