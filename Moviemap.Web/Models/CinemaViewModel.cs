using Microsoft.AspNetCore.Mvc.Rendering;
using Moviemap.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Models
{
    public class CinemaViewModel : CinemaEntity
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Brand")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Brand.")]
        public int BrandId { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }
    }
}
