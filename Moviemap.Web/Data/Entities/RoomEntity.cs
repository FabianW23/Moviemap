using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Data.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public CinemaEntity Cinema { get; set; }

        public ICollection<HourEntity> Hours { get; set; }

        public ICollection<ChairEntity> Chairs { get; set; }
    }
}
