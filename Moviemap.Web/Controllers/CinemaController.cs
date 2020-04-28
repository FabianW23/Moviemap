using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;

namespace Moviemap.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly DataContext _context;

        public CinemaController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cinemas.Include(c => c.User.Id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaEntity = await _context.Cinemas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaEntity == null)
            {
                return NotFound();
            }

            return View(cinemaEntity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaEntity cinemaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinemaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaEntity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaEntity = await _context.Cinemas.FindAsync(id);
            if (cinemaEntity == null)
            {
                return NotFound();
            }
            return View(cinemaEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaEntity cinemaEntity)
        {
            if (id != cinemaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaEntityExists(cinemaEntity.Id))
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
            return View(cinemaEntity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaEntity = await _context.Cinemas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaEntity == null)
            {
                return NotFound();
            }

            return View(cinemaEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaEntity = await _context.Cinemas.FindAsync(id);
            _context.Cinemas.Remove(cinemaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaEntityExists(int id)
        {
            return _context.Cinemas.Any(e => e.Id == id);
        }
    }
}
