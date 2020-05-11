using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class BrandResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoPath { get; set; }

        public string LogoFullPath => string.IsNullOrEmpty(LogoPath)
            ? "https://moviemapweb.azurewebsites.net/images/NoImage.jpg"
            : $"https://moviemapweb.azurewebsites.net{LogoPath.Substring(1)}";
    }
}
