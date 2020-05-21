using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Emuns;
using Moviemap.Common.Models;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using Moviemap.Web.Resources;

namespace Moviemap.Web.Controllers.API
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IUserHelper _userHelper;

        public ReservationController(DataContext context,
            IConverterHelper converterHelper,
            IUserHelper userHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _userHelper = userHelper;
        }

        [HttpPost]
        [Route("GetUserReservations")]
        public async Task<IActionResult> GetUserReservations([FromBody] ReservationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);
            Resource.Culture = cultureInfo;
            UserEntity user = await _userHelper.GetUserAsync(request.UserId.ToString());
            if (user == null)
            {
                return BadRequest(Resource.UserDoesntExists);
            }

            List<ReservationEntity> reservations = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.ReservationChairs)
                .ThenInclude(rc => rc.Chair)
                .Include(r => r.Hour)
                .ThenInclude(h => h.Movie)
                .Include(r => r.Hour)
                .ThenInclude(h => h.Room)
                .ThenInclude(rm => rm.Cinema)
                .ThenInclude(c => c.Brand)
                .Where(u => u.User.Id == request.UserId.ToString())
                .ToListAsync();
            if (reservations.Count == 0)
            {
                return BadRequest(Resource.UserWithOutTrips);
            }
            else
            {
                return Ok(_converterHelper.ToReservationsResponse(reservations));
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("DoReservation")]
        public async Task<IActionResult> DoReservation([FromBody] DoReservationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);
            Resource.Culture = cultureInfo;
            UserEntity user = await _userHelper.GetUserAsync(request.UserId.ToString());
            if (user == null)
            {
                return BadRequest(Resource.UserDoesntExists);
            }
            var reservation = _context.Reservations.Include(r => r.User).Where(r => r.User.Id == user.Id);
            if(reservation != null)
            {
                return BadRequest(Resource.UserHaveAReservationForThisHour);
            }
            List<ReservationChairsEntity> reservationChairs = new List<ReservationChairsEntity>();
            foreach(ChairResponse chair in request.Chairs)
            {
                reservationChairs.Add(new ReservationChairsEntity 
                {
                    Chair = _context.Chairs.Find(chair.Id)
                });
            }

            _context.Reservations.Add(new ReservationEntity
            {
                Status = ReservationStatus.Active,
                User = user,
                Hour = _context.Hours.FirstOrDefault(h => h.Id == request.HourId),
                ReservationChairs = reservationChairs
            });
            await _context.SaveChangesAsync();
            return Ok(new Response
            {
                IsSuccess = true,
                Message = Resource.ReservationAdded
            });

        }
    }
}