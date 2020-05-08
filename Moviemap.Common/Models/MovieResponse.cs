using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class MovieResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoPath { get; set; }

        public int Duration { get; set; }
    }
}
