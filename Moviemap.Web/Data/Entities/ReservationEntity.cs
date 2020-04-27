using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Data.Entities
{
    public class ReservationEntity
    {
        public int Id { get; set; }

        [Display(Name = "Qr Code")]
        public string QrCode { get; set; }

        public bool Status { get; set; }

        public MovieEntity Movie { get; set; }

        public UserEntity User { get; set; }
    }
}
