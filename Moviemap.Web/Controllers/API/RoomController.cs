using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Emuns;
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
    public class RoomController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public RoomController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        [Route("GetRoom")]
        public async Task<IActionResult> GetRoom([FromBody] RoomRequest request)
        {
            List<ReservationEntity> reservations = await _context.Reservations
                .Include(r => r.Hour)
                .Include(r => r.ReservationChairs)
                .ThenInclude(rc => rc.Chair)
                .Where(r => r.Hour.Id == request.HourId)
                .ToListAsync();
            List<ICollection<ReservationChairsEntity>> reservationChairs = reservations.Select(r => r.ReservationChairs).ToList();
            List<ReservationChairsEntity> Chairs = reservationChairs.SelectMany(x => x).ToList();
            List<ChairEntity> indChairs = Chairs.Select(r => r.Chair).ToList();

            RoomEntity roomChairs = _context.Rooms.Include(r => r.Chairs).FirstOrDefault(r => r.Id == request.RoomId);

            foreach(ChairEntity chair in indChairs)
            {
                foreach(ChairEntity entity in roomChairs.Chairs)
                {
                    if (chair.Name == entity.Name)
                    {
                        entity.ChairType = ChairType.NotAvailable;
                    }
                    
                }
            }
            RoomResponse room = _converterHelper.ToRoomResponse(roomChairs);
            if (room == null)
            {
                return BadRequest(Resource.UserWithOutTrips);
            }
            else
            {
                return Ok(room);
            }
        }
    }
}