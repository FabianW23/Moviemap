﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class ReservationResponse
    {
        public int Id { get; set; }

        public string QrCode { get; set; }

        public String Status { get; set; }

        public HourResponse Hour { get; set; }

        public UserResponse User { get; set; }

        public List<ReservationChairsResponse> ReservationChairs { get; set; }
    }
}
