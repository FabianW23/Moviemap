using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Emuns;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            _context = dataContext;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("101010", "Fabian", "Morales", "fabian64.m.d@gmail.com", "304 395 0527", UserType.Admin);
            await CheckUserAsync("202020", "Rocio", "Royal", "fabian.m.d@hotmail.com", "304 395 0527", UserType.CinemaAdmin);
            await CheckUserAsync("303030", "Marin", "Marin", "minertop1023@gmail.com", "304 395 0527", UserType.User);
            await CheckUserAsync("505050", "ferre", "Warchi", "ferre55@yopmail.com", "304 395 0527", UserType.User);
            await CheckCinemaAsync();
        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.CinemaAdmin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType,
                    UserName = email
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckCinemaAsync()
        {
            if (!_context.Cinemas.Any())
            {
                AddCinema("Procinal Puerta de norte", await _userHelper.GetUserByEmailAsync("fabian.m.d@hotmail.com"));
                AddCinema("Procinal Mayorca", await _userHelper.GetUserByEmailAsync("fabian.m.d@hotmail.com"));
                await _context.SaveChangesAsync();
            }
        }

        private void AddCinema(string name, UserEntity user)
        {
            _context.Cinemas.Add(new CinemaEntity
            {
                Name = name,
                User = user
            });
        }
    }
}
