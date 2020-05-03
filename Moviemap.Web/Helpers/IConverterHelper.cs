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
        CinemaEntity ToCinemaEntity(CinemaViewModel model, string path, bool isNew);

        CinemaViewModel ToCinemaViewModel(CinemaEntity countryEntity);

        MovieEntity ToMovieEntity(MovieViewModel model, string path, bool isNew);

        MovieViewModel ToMovieViewModel(MovieEntity movieEntity);

        Task<RoomEntity> ToRoomEntity(RoomViewModel model, bool isNew);

        RoomViewModel ToRoomViewModel(RoomEntity roomEntity, string email);

        Task<HourEntity> ToHourEntity(HourViewModel model, bool isNew);

        HourViewModel ToHourViewModel(HourEntity hourEntity);
    }
}
