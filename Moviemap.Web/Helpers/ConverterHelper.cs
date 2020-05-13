using Moviemap.Common.Models;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IUserHelper _userHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper, IUserHelper userHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _userHelper = userHelper;
        }

        public BrandEntity ToBrandEntity(BrandViewModel model, string path, bool isNew)
        {
            return new BrandEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                LogoPath = path,
            };
        }

        public BrandViewModel ToBrandViewModel(BrandEntity brandEntity)
        {
            return new BrandViewModel
            {
                Id = brandEntity.Id,
                Name = brandEntity.Name,
                LogoPath = brandEntity.LogoPath
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

        public List<ReservationResponse> ToReservationsResponse(List<ReservationEntity> reservations)
        {
            List<ReservationResponse> list = new List<ReservationResponse>();
            foreach (ReservationEntity reservationEntity in reservations)
            {
                list.Add(ToReservationResponse(reservationEntity));
            }

            return list;
        }

        public ReservationResponse ToReservationResponse(ReservationEntity reservationEntity)
        {
            return new ReservationResponse
            {
                Id = reservationEntity.Id,
                Status = reservationEntity.Status,
                Hour = ToHourResponse(reservationEntity.Hour),
                ReservationChairs = reservationEntity.ReservationChairs.Select(rc => new ReservationChairsResponse
                {
                    Id = rc.Id,
                    Chair = ToChairResponse(rc.Chair)
                }).ToList()
            };
        }

        public ChairResponse ToChairResponse(ChairEntity model)
        {
            return new ChairResponse
            {
                Id = model.Id,
                ChairType = model.ChairType,
                Name = model.Name,
                ColumnLocation = model.ColumnLocation,
                RowLocation = model.RowLocation
            };
        }

        public HourResponse ToHourResponse(HourEntity model)
        {
            return new HourResponse
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TicketPrice = model.TicketPrice,
                Movie = ToMovieResponse(model.Movie),
                Room = ToRoomResponse(model.Room)
            };
        }

        public MovieResponse ToMovieResponse(MovieEntity model)
        {
            return new MovieResponse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                LogoPath = model.LogoPath
            };
        }

        public MovieResponse ToMovieResponse(MovieEntity model, int cinemaId)
        {
            return new MovieResponse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                LogoPath = model.LogoPath,
                Hours = model.Hours.Select(h => new HourResponse
                {
                    Id = h.Id,
                    StartDate = h.StartDate,
                    EndDate = h.EndDate,
                    TicketPrice = h.TicketPrice,
                    Room = ToRoomResponse(h.Room)
                }).Where(h => h.Room.Cinema.Id == cinemaId)
                .ToList()
            };
        }

        public RoomResponse ToRoomResponse(RoomEntity model)
        {
            return new RoomResponse
            {
                Id = model.Id,
                Name = model.Name,
                Cinema = ToCinemaResponse(model.Cinema)
            };
        }

        public CinemaResponse ToCinemaResponse(CinemaEntity model)
        {
            return new CinemaResponse
            {
                Id = model.Id,
                Name = model.Name,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Brand = ToBrandResponse(model.Brand)
            };
        }

        public BrandResponse ToBrandResponse(BrandEntity model)
        {
            return new BrandResponse
            {
                Id = model.Id,
                Name = model.Name,
                LogoPath = model.LogoPath
            };
        }

        public List<CinemaResponse> ToCinemaResponse(List<CinemaEntity> cinemas)
        {
            List<CinemaResponse> list = new List<CinemaResponse>();
            foreach (CinemaEntity cinemaEntity in cinemas)
            {
                list.Add(ToCinemaResponse(cinemaEntity));
            }

            return list;
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

        public async Task<CinemaEntity> ToCinemaEntity(CinemaViewModel model, bool isNew, string userEmail)
        {
            return new CinemaEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Rooms = model.Rooms,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                User = await _userHelper.GetUserByEmailAsync(userEmail),
                Brand = await _context.Brands.FindAsync(model.BrandId)
            };
        }

        public CinemaViewModel ToCinemaViewModel(CinemaEntity cinemaEntity)
        {
            return new CinemaViewModel
            {
                Id = cinemaEntity.Id,
                Name = cinemaEntity.Name,
                Latitude = cinemaEntity.Latitude,
                Longitude = cinemaEntity.Longitude,
                Rooms = cinemaEntity.Rooms,
                Brand = cinemaEntity.Brand,
                BrandId = cinemaEntity.Brand.Id,
                User = cinemaEntity.User,
                Brands = _combosHelper.GetComboBrands()
            };
        }

        public List<MovieResponse> ToMovieResponse(List<MovieEntity> movies, int cinemaId)
        {
            List<MovieResponse> list = new List<MovieResponse>();
            foreach (MovieEntity movieEntity in movies)
            {
                MovieResponse movieResponse = ToMovieResponse(movieEntity, cinemaId);
                if (movieResponse.Hours.Count != 0)
                {
                    list.Add(movieResponse);
                }

            }

            return list;
        }
    }
}
