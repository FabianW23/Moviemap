using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly DataContext _context;

        public ReservationController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "CinemaAdmin,Admin")]
        public async Task<IActionResult> Index()
        {
            List<ReservationEntity> reservation = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.ReservationChairs)
                .ThenInclude(rc => rc.Chair)
                .Include(r => r.Hour)
                .ThenInclude(h => h.Movie)
                .Include(r => r.Hour)
                .ThenInclude(h => h.Room)
                .ToListAsync();
            return View(reservation);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReservationEntity reservationEntity = await _context.Reservations
                .Include(r => r.ReservationChairs)
                .Include(r => r.Hour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationEntity == null)
            {
                return NotFound();
            }

            return View(reservationEntity);
        }
    }
}
