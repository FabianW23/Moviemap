using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class ReservationChairsResponse
    {
        public int Id { get; set; }

        public ChairResponse Chair { get; set; }
    }
}
