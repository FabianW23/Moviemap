using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Models;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public CinemaEntity ToCinemaEntity(CinemaViewModel model, string path, bool isNew)
        {
            return new CinemaEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name,
                User = model.User
            };
        }

        public CinemaViewModel ToCinemaViewModel(CinemaEntity cinemaEntity)
        {
            return new CinemaViewModel
            {
                Id = cinemaEntity.Id,
                LogoPath = cinemaEntity.LogoPath,
                Name = cinemaEntity.Name,
                User = cinemaEntity.User
            };
        }

        public async Task<HourEntity> ToHourEntity(HourViewModel model, bool isNew)
        {
            return new HourEntity
            {
                Id = isNew ? 0 : model.Id,
                TicketPrice = model.TicketPrice,
                StartDate = model.StartDate.ToUniversalTime(),
                EndDate = model.EndDate.ToUniversalTime(),
                IsAvalible = model.IsAvalible,
                Movie = await _context.Movies.FindAsync(model.MovieId),
                Room = await _context.Rooms.FindAsync(model.RoomId)
            };
        }

        public HourViewModel ToHourViewModel(HourEntity hourEntity)
        {
            return new HourViewModel
            {
                TicketPrice = hourEntity.TicketPrice,
                StartDate = hourEntity.StartDate.ToLocalTime(),
                EndDate = hourEntity.EndDate.ToLocalTime(),
                IsAvalible = hourEntity.IsAvalible,
                RoomId = hourEntity.Room.Id,
                Movie = hourEntity.Movie,
                Movies = _combosHelper.GetComboMovies(),
                MovieId = hourEntity.Movie.Id
            };
        }

        public MovieEntity ToMovieEntity(MovieViewModel model, string path, bool isNew)
        {
            return new MovieEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration
            };
        }

        public MovieViewModel ToMovieViewModel(MovieEntity movieEntity)
        {
            return new MovieViewModel
            {
                Id = movieEntity.Id,
                LogoPath = movieEntity.LogoPath,
                Name = movieEntity.Name,
                Description = movieEntity.Description,
                Duration = movieEntity.Duration
            };
        }

        public async Task<RoomEntity> ToRoomEntity(RoomViewModel model, bool isNew)
        {
            return new RoomEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Cinema = await _context.Cinemas.FindAsync(model.CinemaId)
            };
        }

        public RoomViewModel ToRoomViewModel(RoomEntity roomEntity, string userEmail)
        {
            return new RoomViewModel
            {
                Name = roomEntity.Name,
                Cinema = roomEntity.Cinema,
                CinemaId = roomEntity.Cinema.Id,
                Cinemas = _combosHelper.GetComboCinemas(userEmail)
            };
        }

        public UserResponse ToUserResponse(UserEntity user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType
            };
        }
    }
}
