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
    public class RoomController : Controller
    {
        private readonly DataContext _context;

        public RoomController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Rooms.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomEntity = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomEntity == null)
            {
                return NotFound();
            }

            return View(roomEntity);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RoomEntity roomEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomEntity);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomEntity = await _context.Rooms.FindAsync(id);
            if (roomEntity == null)
            {
                return NotFound();
            }
            return View(roomEntity);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RoomEntity roomEntity)
        {
            if (id != roomEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomEntityExists(roomEntity.Id))
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
            return View(roomEntity);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomEntity = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomEntity == null)
            {
                return NotFound();
            }

            return View(roomEntity);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomEntity = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(roomEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomEntityExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
