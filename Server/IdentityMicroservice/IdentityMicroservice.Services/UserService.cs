﻿using Common.DependencyInjection;
using IdentityMicroservice.DataAccess;
using IdentityMicroservice.DataAccess.Entities;
using IdentityMicroservice.Services.Interfaces;
using IdentityMicroservice.TokenManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserModel = IdentityMicroservice.DataPresentation.Models.User;

namespace IdentityMicroservice.Services
{
     public class UserService : BaseService, IUserService, IScopedService
     {
          private readonly int _iterationsCount = 10000;
          private readonly int _saltSize = 16;
          private readonly int _hashedPassSize = 49;

          private readonly IJwtBuilder _jwtBuilder;

          public UserService(IUnitOfWork unitOfWork, IJwtBuilder jwtBuilder) : base(unitOfWork)
          {
               _jwtBuilder = jwtBuilder;
          }

          public async Task<User> Register(UserModel registrationInfo)
          {
               if (string.IsNullOrEmpty(registrationInfo.Name) || string.IsNullOrEmpty(registrationInfo.Login)
                 || string.IsNullOrEmpty(registrationInfo.Password))
               {
                    return null;
               }

               var searchUser = await Db.Users.FindBy(u => u.Login == registrationInfo.Login).FirstOrDefaultAsync();
               var userExists = searchUser != null;
               if (!userExists)
               {
                    var user = new User
                    {
                         Name = registrationInfo.Name,
                         Login = registrationInfo.Login,
                         PasswordHash = HashPassword(registrationInfo.Password),
                         IsAdmin = false
                    };

                    await Db.Users.Add(user);
                    await Db.Save();

                    return user;
               }

               return null;
          }

          public async Task<UserModel> TryAuthenticate(string login, string password)
          {
               try
               {
                    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                    {
                         return null;
                    }
                    var user = await Db.Users.FindBy(u => u.Login == login).FirstOrDefaultAsync();
                    if (user == null) return null;

                    if (!IsValidPassword(user.PasswordHash, password)) return null;

                    var userModel = new UserModel
                    {
                         Id = user.Id,
                         Name = user.Name,
                         Login = user.Login,
                         IsAdmin = user.IsAdmin
                    };

                    var accessToken = _jwtBuilder.GetAccessToken(userModel);

                    var refreshToken = _jwtBuilder.GenerateRefreshToken();

                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7); //!!!!!

                    await Db.Save();

                    userModel.AccessToken = accessToken;
                    userModel.RefreshToken = refreshToken;

                    return userModel;
               }
               catch (Exception)
               {
                    return null;
               }
          }

          public async Task<UserModel> RefreshToken(string accessToken, string refreshToken)
          {
               var principal = _jwtBuilder.GetPrincipalFromExpiredToken(accessToken);
               var login = principal.Claims.FirstOrDefault(c => c.Type == "Login")?.Value;
               var user = await Db.Users.FindBy(u => u.Login == login).FirstOrDefaultAsync();
               if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
               {
                    return null;
               }

               var userModel = new UserModel
               {
                    Id = user.Id,
                    Name = user.Name,
                    Login = user.Login,
                    IsAdmin = user.IsAdmin
               };

               var newAccessToken = _jwtBuilder.GetAccessToken(userModel);
               var newRefreshToken = _jwtBuilder.GenerateRefreshToken();

               user.RefreshToken = newRefreshToken;
               await Db.Save();

               userModel.AccessToken = newAccessToken;
               userModel.RefreshToken = newRefreshToken;
               
               return userModel;
          }

          private string HashPassword(string password)
          {
               byte[] salt;
               byte[] buffer;
               using (var bytes = new Rfc2898DeriveBytes(password, _saltSize, _iterationsCount))
               {
                    salt = bytes.Salt;
                    buffer = bytes.GetBytes(32);
               }
               byte[] dst = new byte[_hashedPassSize];
               Buffer.BlockCopy(salt, 0, dst, 1, 16);
               Buffer.BlockCopy(buffer, 0, dst, 17, 32);
               return Convert.ToBase64String(dst);
          }

          private bool IsValidPassword(string hashedPassword, string password)
          {
               if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(password))
               {
                    return false;
               }
               var src = Convert.FromBase64String(hashedPassword);
               if ((src.Length != _hashedPassSize) || (src[0] != 0))
               {
                    return false;
               }

               byte[] currentPasswordBuffer;
               var salt = new byte[_saltSize];
               Buffer.BlockCopy(src, 1, salt, 0, _saltSize);
               var hashedPasswordBuffer = new byte[32];
               Buffer.BlockCopy(src, 17, hashedPasswordBuffer, 0, 32);
               using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt, _iterationsCount))
               {
                    currentPasswordBuffer = bytes.GetBytes(32);
               }
               return CompareArrays(hashedPasswordBuffer, currentPasswordBuffer);
          }

          private bool CompareArrays(byte[] arr1, byte[] arr2)
          {
               if (arr1.Length != arr2.Length)
               {
                    return false;
               }
               for (int i = 0; i < arr1.Length; i++)
               {
                    if (arr1[i] != arr2[i])
                    {
                         return false;
                    }
               }
               return true;
          }
     }
}
