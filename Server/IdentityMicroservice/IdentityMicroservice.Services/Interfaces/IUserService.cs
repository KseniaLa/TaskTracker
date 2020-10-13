using IdentityMicroservice.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserModel = IdentityMicroservice.DataPresentation.Models.User;

namespace IdentityMicroservice.Services.Interfaces
{
     public interface IUserService
     {
          Task<UserModel> TryAuthenticate(string email, string password);

          Task<User> Register(UserModel registrationInfo);

          Task<UserModel> RefreshToken(string accessToken, string refreshToken);
     }
}
