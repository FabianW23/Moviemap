using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moviemap.Common.Models
{
    public class CinemaMoviesRequest
    {
        [Required]
        public int CinemaId { get; set; }

        [Required]
        public string CultureInfo { get; set; }

    }
}
