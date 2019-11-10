using LogMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMicroservice.DataAccess
{
     public interface ILogDbContext
     {
          DbSet<ClientLog> ClientLogs { get; set; }
     }
}
