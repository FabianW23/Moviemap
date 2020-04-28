using Microsoft.AspNetCore.Identity;
using Moviemap.Common.Emuns;
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

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task<UserEntity> GetUserByEmailAsync(string email);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task CheckRoleAsync(string roleName);

        Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user);

        Task<IdentityResult> ConfirmEmailAsync(UserEntity user, string token);
    }
}
