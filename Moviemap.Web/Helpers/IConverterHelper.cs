using Moviemap.Common.Models;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public interface IConverterHelper
    {
        BrandEntity ToBrandEntity(BrandViewModel model, string path, bool isNew);

        BrandViewModel ToBrandViewModel(BrandEntity countryEntity);

        MovieEntity ToMovieEntity(MovieViewModel model, string path, bool isNew);

        MovieViewModel ToMovieViewModel(MovieEntity movieEntity);

        Task<RoomEntity> ToRoomEntity(RoomViewModel model, bool isNew);

        RoomViewModel ToRoomViewModel(RoomEntity roomEntity, string email);

        Task<HourEntity> ToHourEntity(HourViewModel model, bool isNew);

        HourViewModel ToHourViewModel(HourEntity hourEntity);

        UserResponse ToUserResponse(UserEntity model);

        List<ReservationResponse> ToReservationResponse(List<ReservationEntity> reservations);

        Task<CinemaEntity> ToCinemaEntity(CinemaViewModel model, bool isNew, string email);

        CinemaViewModel ToCinemaViewModel(CinemaEntity cinemaEntity);

    }
}
