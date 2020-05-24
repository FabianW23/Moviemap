﻿using Microsoft.AspNetCore.Identity;
using Moviemap.Common.Emuns;
using Moviemap.Common.Models;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> AddUserAsync(AddUserViewModel model, UserType userType);

        Task<UserEntity> AddUserAsync(FacebookProfile model);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task<UserEntity> GetUserByEmailAsync(string email);

        Task<UserEntity> GetUserAsync(string userId);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task CheckRoleAsync(string roleName);

        Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user);

        Task<IdentityResult> ConfirmEmailAsync(UserEntity user, string token);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task<SignInResult> ValidatePasswordAsync(UserEntity user, string password);

        Task LogoutAsync();

        Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(UserEntity user);

        Task<string> GeneratePasswordResetTokenAsync(UserEntity user);

        Task<IdentityResult> ResetPasswordAsync(UserEntity user, string token, string password);

    }
}
