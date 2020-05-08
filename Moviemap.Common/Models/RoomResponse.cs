using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class RoomResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CinemaResponse Cinema { get; set; }

        public List<ChairResponse> Chairs { get; set; }
    }
}
