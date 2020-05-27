using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Common.Emuns;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using System;
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
                .ThenInclude(r => r.Cinema)
                .Where(r => r.Hour.Room.Cinema.User.Email == User.Identity.Name)
                .ToListAsync();
            foreach (ReservationEntity reservation1 in reservation)
            {
                if(reservation1.Hour.StartDate < DateTime.Now)
                {
                    reservation1.Status = ReservationStatus.TimeOut;
                }
            }
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
                .ThenInclude(rc => rc.Chair)
                .Include(r => r.User)
                .Include(r => r.Hour)
                .ThenInclude(h => h.Movie)
                .Include(r => r.Hour)
                .ThenInclude(h => h.Room)
                .ThenInclude(h => h.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationEntity == null)
            {
                return NotFound();
            }
            if (reservationEntity.Hour.StartDate < DateTime.Now)
            {
                reservationEntity.Status = ReservationStatus.TimeOut;
            }
            return View(reservationEntity);
        }
    }
}
