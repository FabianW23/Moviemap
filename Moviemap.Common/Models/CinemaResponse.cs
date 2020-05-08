using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class CinemaResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoPath { get; set; }

        public UserResponse User { get; set; }
    }
}
