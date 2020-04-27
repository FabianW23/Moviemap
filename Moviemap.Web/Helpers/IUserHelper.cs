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

        Task<UserEntity> GetUserByEmailAsync(string email);

        Task AddUserToRoleAsync(UserEntity user, string roleName);
    }
}
