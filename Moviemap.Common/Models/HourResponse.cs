using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class HourResponse
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public DateTime EndDate { get; set; }

        public DateTime EndDateLocal => EndDate.ToLocalTime();

        public decimal TicketPrice { get; set; }

        public bool IsAvalible { get; set; }

        public RoomResponse Room { get; set; }

        public MovieResponse Movie { get; set; }

    }
}
