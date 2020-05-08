using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Data.Entities
{
    public class CinemaEntity
    {
        public int Id { get; set; }

        [Display(Name = "Cinema")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public float Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public float Longitude { get; set; }

        public UserEntity User { get; set; }

        public BrandEntity Brand { get; set; }

        public ICollection<RoomEntity> Rooms { get; set; }
    }
}
