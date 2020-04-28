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
            await CheckMovieAsync();
            await CheckRoomAsync();
            await CheckHoursAsync();
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
            UserEntity user = await _userHelper.GetUserByEmailAsync(email);
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
                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckMovieAsync()
        {
            if (!_context.Movies.Any())
            {
                AddMovie("BLACK WIDOW", "Despues de los sucesos de Capitán América: Civil War, Natasha Romanoff se encuentra sola y obligada a enfrentar su pasado mientras es buscada por la ley.", 120);
                AddMovie("GHOSTBUSTERS: EL LEGADO", "Del director Jason Reitman y el productor Ivan Reitman, llega el próximo capítulo del universo original de Los Cazafantasmas. En Ghostbusters: El Legado, una madre soltera y sus dos hijos llegan a un pequeño pueblo y comienzan a descubrir su conexión con los cazafantasmas originales y el legado secreto que dejó su abuelo. La película está escrita por Jason Reitman y Gil Kenan.", 150);
                AddMovie("EL JARDÍN SECRETO", "Cuando la pequeña Mary Lennox pierde a sus padres, se ve obligada a dejar India, el único hogar que conoce, para llegar a Inglaterra a la aislada mansión de su tío (Colin Firth). En su nuevo hogar Mary conoce a su primo, quien nunca ha salido de su habitación, y deberá lidiar con la poco amable señora Medloc (Julie Walters), al tiempo que devela los misterios de su nueva familia. Pronto, Mary descubrirá el secreto que esconde la mansión: un jardín mágico en donde suceden cosas extraordinarias. Sin saberlo, mejorará las vidas de todos las que la rodean en esta nueva adaptación de la famosa novela.", 180);
                AddMovie("MUJER MARAVILLA 1984", "Avancemos rápidamente a la década de 1980 cuando la próxima aventura en la pantalla grande de Mujer Maravilla la encuentra frente a dos enemigos completamente nuevos: Max Lord y Cheetah.", 150);
                AddMovie("TENET", "Una película de Christopher Nolan. TENET, próximamente solo en cines.", 140);
                await _context.SaveChangesAsync();
            }
        }

        private void AddMovie(string name, string description, int duration)
        {
            _context.Movies.Add(new MovieEntity
            {
                Name = name,
                Description = description,
                Duration = duration
            });
        }

        private async Task CheckCinemaAsync()
        {
            if (!_context.Movies.Any())
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

        private async Task CheckHoursAsync()
        {
            if (!_context.Hours.Any())
            {
                await AddHourssync(1, new DateTime(2020, 4, 29, 13, 10, 0), new DateTime(2020, 4, 29, 16, 10, 0), "BLACK WIDOW");
                await AddHourssync(1, new DateTime(2020, 4, 29, 16, 0, 0), new DateTime(2020, 4, 29, 19, 20, 0), "GHOSTBUSTERS: EL LEGADO");
                await AddHourssync(1, new DateTime(2020, 4, 29, 19, 20, 0), new DateTime(2020, 4, 29, 21, 10, 0), "EL JARDÍN SECRETO");
                await AddHourssync(1, new DateTime(2020, 4, 29, 21, 5, 0), new DateTime(2020, 4, 29, 23, 45, 0), "BLACK WIDOW");
                await _context.SaveChangesAsync();
            }
        }


        private async Task AddHourssync(int roomId, DateTime startDate, DateTime endtDate, string movie)
        {
            _context.Hours.Add(new HourEntity
            {
                StartDate = startDate,
                EndDate = endtDate,
                TicketPrice = 13000,
                Movie = _context.Movies.FirstOrDefault(m => m.Name == movie),
                Room = _context.Rooms.FirstOrDefault(r => r.Id == roomId)
            });
            await _context.SaveChangesAsync();
        }

        private async Task CheckRoomAsync()
        {
            if (!_context.Rooms.Any())
            {
                await AddRoomAsync("Procinal Puerta de norte", "Sala 1");
                await AddRoomAsync("Procinal Puerta de norte", "Sala 2");
                await AddRoomAsync("Procinal Mayorca", "Sala 1");
                await AddRoomAsync("Procinal Mayorca", "Sala 2");
                await _context.SaveChangesAsync();
            }
        }

        private async Task AddRoomAsync(string cinemaName, string salaName)
        {
            _context.Rooms.Add(new RoomEntity 
            { 
                Name = salaName, 
                Cinema = _context.Cinemas.FirstOrDefault(c => c.Name == cinemaName)
            });
        }
    }
}
