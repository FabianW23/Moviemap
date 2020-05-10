using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Models;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using Moviemap.Web.Resources;

namespace Moviemap.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IConverterHelper _converterHelper;
        private readonly DataContext _context;

        public CinemaController(IConverterHelper converterHelper, DataContext context)
        {
            _converterHelper = converterHelper;
            _context = context;
        }

        [HttpPost]
        [Route("GetCinemas")]
        public async Task<IActionResult> GetCinemas()
        {
            List<CinemaEntity> cinemas = await _context.Cinemas
                .Include(c => c.Brand)
                .OrderBy(c => c.Brand.Name)
                .ToListAsync();
            if (cinemas.Count == 0)
            {
                return BadRequest(Resource.UserWithOutTrips);
            }
            else
            {
                return Ok(_converterHelper.ToCinemaResponse(cinemas));
            }
        }

        
    }
}