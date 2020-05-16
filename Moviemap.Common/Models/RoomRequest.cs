using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moviemap.Common.Models
{
    public class RoomRequest
    {
        public int RoomId { get; set; }

        public int HourId { get; set; }

        public string CultureInfo { get; set; }
    }
}
