using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class DoReservationRequest
    {
        public int HourId { get; set; }

        public Guid UserId { get; set; }

        public List<ChairResponse> Chairs { get; set; }

        public string CultureInfo { get; set; }
    }
}
