using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Models;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using Moviemap.Web.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IConverterHelper _converterHelper;
        private readonly DataContext _context;

        public MovieController(IConverterHelper converterHelper, DataContext context)
        {
            _converterHelper = converterHelper;
            _context = context;
        }

        [HttpPost]
        [Route("GetCinemaMovies")]
        public async Task<IActionResult> GetCinemaMovies([FromBody] CinemaMoviesRequest request)
        {
            List<MovieEntity> movies = await _context.Movies
                .Include(m => m.Hours)
                .ThenInclude(h => h.Room)
                .ThenInclude(r => r.Cinema)
                .ThenInclude(c => c.Brand)
                .OrderBy(m => m.Name)
                .ToListAsync();
            if (movies.Count == 0)
            {
                return BadRequest(Resource.WithOutDatasAvaliables);
            }
            List<MovieResponse> movieResponse = _converterHelper.ToMovieResponse(movies, request.CinemaId);
            if (movieResponse.Count == 0)
            {
                return BadRequest(Resource.WithOutDatasAvaliables);
            }
            else
            {
                return Ok(movieResponse);
            }
        }
    }
}