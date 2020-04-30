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
    }
}
