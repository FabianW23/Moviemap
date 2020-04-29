using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Data.Entities
{
    public class ReservationChairsEntity
    {
        public int Id { get; set; }

        public ReservationEntity Reservation { get; set; }

        public ChairEntity Chair { get; set; }
    }
}
