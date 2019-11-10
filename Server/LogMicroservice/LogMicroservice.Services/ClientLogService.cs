using LogMicroservice.Config;
using LogMicroservice.DataAccess;
using LogMicroservice.DataAccess.Entities;
using LogMicroservice.DataPresentation.Models;
using LogMicroservice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogMicroservice.Services
{
     public class ClientLogService : BaseService, IClientLogService, IScopedService
     {
          private readonly IConfig _config;

          public ClientLogService(IUnitOfWork unitOfWork, IConfig config) : base(unitOfWork)
          {
               _config = config;
          }

          public async Task AddLogs(ClientLogItem[] logs)
          {
               foreach (var log in logs)
               {
                    if (log == null) continue;

                    var ipAddress = new ClientLog
                    {
                         Level = log.Level,
                         Message = log.Message,
                         Timestamp = log.Timestamp
                    };

                    await Db.ClientLogs.Add(ipAddress);
               }

               await Db.Save();
          }
     }
}
