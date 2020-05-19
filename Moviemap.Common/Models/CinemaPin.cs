using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class CinemaPin
    {
        public int CinemaId { get; set; }

        public string CinemaName { get; set; }

        public Position CinemaPosition { get; set; }
    }
}
