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

        // GET: Reservation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QrCode,Status")] ReservationEntity reservationEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationEntity);
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReservationEntity reservationEntity = await _context.Reservations.FindAsync(id);
            if (reservationEntity == null)
            {
                return NotFound();
            }
            return View(reservationEntity);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QrCode,Status")] ReservationEntity reservationEntity)
        {
            if (id != reservationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationEntityExists(reservationEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationEntity);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ReservationEntity reservationEntity = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservationEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationEntityExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
