using Microsoft.AspNetCore.Http;
using Moviemap.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Models
{
    public class BrandViewModel : BrandEntity
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
