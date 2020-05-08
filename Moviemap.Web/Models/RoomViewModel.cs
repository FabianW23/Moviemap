using Microsoft.AspNetCore.Mvc.Rendering;
using Moviemap.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Models
{
    public class RoomViewModel : RoomEntity
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Cinema")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Cinema.")]
        public int CinemaId { get; set; }

        public IEnumerable<SelectListItem> Cinemas { get; set; }
    }
}
