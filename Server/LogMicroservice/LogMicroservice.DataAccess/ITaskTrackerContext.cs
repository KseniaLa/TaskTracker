using LogMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.DataAccess
{
     public interface ITaskTrackerContext
     {
          DbSet<ClientLog> ClientLogs { get; set; }
     }
}
