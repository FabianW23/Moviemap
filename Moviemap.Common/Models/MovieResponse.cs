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

        public string TrailerUrl { get; set; }

        public string LogoPath { get; set; }

        public string LogoFullPath => string.IsNullOrEmpty(LogoPath)
            ? "https://moviemapweb.azurewebsites.net/images/NoImage.jpg"
            : $"https://moviemapweb.azurewebsites.net{LogoPath.Substring(1)}";

        public int Duration { get; set; }

        public List<HourResponse> Hours { get; set; }
    }
}
