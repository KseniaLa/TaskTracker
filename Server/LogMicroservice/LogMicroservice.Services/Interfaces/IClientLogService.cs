using LogMicroservice.DataPresentation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogMicroservice.Services.Interfaces
{
     public interface IClientLogService
     {
          Task AddLogs(ClientLogItem[] logs);
     }
}
