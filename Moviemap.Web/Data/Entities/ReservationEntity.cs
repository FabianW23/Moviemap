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

        [Display(Name = "Total Amount")]
        public decimal Total => Hour == null ? 0 : Hour.TicketPrice * ReservationChairs.Count;

        public string Status { get; set; }

        

        public HourEntity Hour { get; set; }

        public UserEntity User { get; set; }

        public ICollection<ReservationChairsEntity> ReservationChairs { get; set; }
    }
}
