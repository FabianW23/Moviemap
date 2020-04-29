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
                Name = model.Name
            };
        }

        public CinemaViewModel ToCinemaViewModel(CinemaEntity cinemaEntity)
        {
            return new CinemaViewModel
            {
                Id = cinemaEntity.Id,
                LogoPath = cinemaEntity.LogoPath,
                Name = cinemaEntity.Name
            };
        }
    }
}
