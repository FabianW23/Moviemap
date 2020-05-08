using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using Moviemap.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Controllers
{
    
    public class CinemaController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly ICombosHelper _combosHelper;

        public CinemaController(DataContext context, IConverterHelper converterHelper, ICombosHelper combosHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _combosHelper = combosHelper;
        }

        [Authorize(Roles = "CinemaAdmin,Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cinemas.Include(c => c.User).ToListAsync());
        }

        [Authorize(Roles = "CinemaAdmin,Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinemaEntity cinemaEntity = await _context.Cinemas
                .Include(c => c.User)
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaEntity == null)
            {
                return NotFound();
            }

            return View(cinemaEntity);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public IActionResult Create()
        {
            CinemaViewModel model = new CinemaViewModel
            {
                Brands = _combosHelper.GetComboBrands()
            };
            return View(model);
        }

        [Authorize(Roles = "CinemaAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaViewModel cinemaViewModel)
        {
            if (ModelState.IsValid)
            {
                CinemaEntity cinemaEntity = await _converterHelper.ToCinemaEntity(cinemaViewModel, true, User.Identity.Name);
                _context.Add(cinemaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            cinemaViewModel.Brand = await _context.Brands.FindAsync(cinemaViewModel.BrandId);
            cinemaViewModel.Brands = _combosHelper.GetComboBrands();
            return View(cinemaViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinemaEntity cinemaEntity = await _context.Cinemas.Include(r => r.Brand)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (cinemaEntity == null)
            {
                return NotFound();
            }
            CinemaViewModel cinemaViewModel = _converterHelper.ToCinemaViewModel(cinemaEntity);
            return View(cinemaViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CinemaViewModel cinemaViewModel)
        {
            if (ModelState.IsValid)
            {
                CinemaEntity cinemaEntity = await _converterHelper.ToCinemaEntity(cinemaViewModel, false, User.Identity.Name);
                _context.Update(cinemaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            cinemaViewModel.Brand = await _context.Brands.FindAsync(cinemaViewModel.BrandId);
            cinemaViewModel.Brands = _combosHelper.GetComboBrands();
            return View(cinemaViewModel);
        }

        [Authorize(Roles = "CinemaAdmin,Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinemaEntity cinemaEntity = await _context.Cinemas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaEntity == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinemaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

