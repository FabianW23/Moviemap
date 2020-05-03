using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using Moviemap.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public RoomController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Rooms
                .Include(r => r.Cinema)
                .Where(r => r.Cinema.User.Email == User.Identity.Name)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomEntity roomEntity = await _context.Rooms
                .Include(r => r.Cinema)
                .Include(r => r.Hours)
                .ThenInclude(h => h.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomEntity == null)
            {
                return NotFound();
            }

            return View(roomEntity);
        }

        public async Task<IActionResult> AddHour(int? id)
        {
            RoomEntity roomEntity = await _context.Rooms.FindAsync(id);
            HourViewModel hourViewModel = new HourViewModel
            {
                RoomId = roomEntity.Id,
                Movies = _combosHelper.GetComboMovies()
            };
            return View(hourViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHour(HourViewModel hourViewModel)
        {
            if (ModelState.IsValid)
            {
                HourEntity hourEntity = await _converterHelper.ToHourEntity(hourViewModel, true);
                _context.Add(hourEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hourViewModel);
        }

        public IActionResult Create()
        {
            RoomViewModel model = new RoomViewModel
            {
                Cinemas = _combosHelper.GetComboCinemas(User.Identity.Name)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomEntity roomEntity = await _converterHelper.ToRoomEntity(roomViewModel, true);
                _context.Add(roomEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            roomViewModel.Cinema = await _context.Cinemas.FindAsync(roomViewModel.CinemaId);
            roomViewModel.Cinemas = _combosHelper.GetComboCinemas(User.Identity.Name);
            return View(roomViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomEntity roomEntity = await _context.Rooms.Include(r => r.Cinema)
                .FirstOrDefaultAsync(r => r.Id == id); ;
            if (roomEntity == null)
            {
                return NotFound();
            }
            RoomViewModel model = _converterHelper.ToRoomViewModel(roomEntity, User.Identity.Name);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomEntity roomEntity = await _converterHelper.ToRoomEntity(roomViewModel, false);
                _context.Update(roomEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            roomViewModel.Cinema = await _context.Cinemas.FindAsync(roomViewModel.CinemaId);
            roomViewModel.Cinemas = _combosHelper.GetComboCinemas(User.Identity.Name);
            return View(roomViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomEntity roomEntity = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomEntity == null)
            {
                return NotFound();
            }

            return View(roomEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            RoomEntity roomEntity = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(roomEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomEntityExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        public async Task<IActionResult> EditHour(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HourEntity hourEntity = await _context.Hours
                .Include(h => h.Room)
                .Include(h => h.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hourEntity == null)
            {
                return NotFound();
            }
            HourViewModel hourViewModel = _converterHelper.ToHourViewModel(hourEntity);
            return View(hourViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHour(HourViewModel model)
        {
            if (ModelState.IsValid)
            {
                HourEntity hourEntity = await _converterHelper.ToHourEntity(model, false);
                _context.Update(hourEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
