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
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public CinemaController(DataContext context, IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            CinemaViewModel cinemaViewModel = _converterHelper.ToCinemaViewModel(cinemaEntity);
            if (cinemaEntity == null)
            {
                return NotFound();
            }

            return View(cinemaViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "CinemaAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaViewModel cinemaViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (cinemaViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(cinemaViewModel.LogoFile, "Cinemas");
                }
                CinemaEntity cinemaEntity = _converterHelper.ToCinemaEntity(cinemaViewModel, path, true);
                _context.Add(cinemaEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exists a country with the same name");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(cinemaViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinemaEntity cinemaEntity = await _context.Cinemas.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, CinemaViewModel cinemaViewModel)
        {
            if (id != cinemaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string path = cinemaViewModel.LogoPath;
                if (cinemaViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(cinemaViewModel.LogoFile, "Cinemas");
                }
                CinemaEntity cinemaEntity = _converterHelper.ToCinemaEntity(cinemaViewModel, path, false);
                _context.Update(cinemaEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exists a country with the same name");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
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

