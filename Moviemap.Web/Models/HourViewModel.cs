using Microsoft.AspNetCore.Mvc.Rendering;
using Moviemap.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Models
{
    public class HourViewModel : HourEntity
    {
        public int RoomId { get; set; }

        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        public IEnumerable<SelectListItem> Movies { get; set; }
    }
}
