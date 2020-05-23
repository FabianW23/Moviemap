using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Moviemap.Web.Data.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Description { get; set; }

        [Display(Name = "Trailer URL")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string TrailerUrl { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Logo")]
        public string LogoFullPath => string.IsNullOrEmpty(LogoPath)
            ? "https://moviemapweb.azurewebsites.net/images/NoImage.jpg"
            : $"https://moviemapweb.azurewebsites.net{LogoPath.Substring(1)}";

        public int Duration { get; set; }

        public ICollection<HourEntity> Hours { get; set; }
    }
}
