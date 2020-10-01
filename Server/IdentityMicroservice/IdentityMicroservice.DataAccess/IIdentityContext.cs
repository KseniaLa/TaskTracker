using IdentityMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMicroservice.DataAccess
{
     public interface IIdentityContext
     {
          DbSet<User> Users { get; set; }
     }
}
