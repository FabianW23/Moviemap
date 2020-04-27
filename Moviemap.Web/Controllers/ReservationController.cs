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

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            List<ReservationEntity> reservation = await _context.Reservations
                .Include(r =>r.Chairs)
                .Include(r =>r.User)
                .Include(r =>r.Movie)
                .ToListAsync();
            return View(reservation);
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReservationEntity reservationEntity = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationEntity == null)
            {
                return NotFound();
            }

            return View(reservationEntity);
        }
    }
}
