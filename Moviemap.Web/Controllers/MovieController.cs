using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using Moviemap.Web.Helpers;
using Moviemap.Web.Models;
using System;
using System.Threading.Tasks;

namespace Moviemap.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public MovieController(DataContext context, IConverterHelper converterHelper, IImageHelper imageHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        [Authorize(Roles = "CinemaAdmin,Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        [Authorize(Roles = "CinemaAdmin,Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieEntity movieEntity = await _context.Movies
                .Include(m => m.Hours)
                .ThenInclude(h => h.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return View(movieEntity);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "CinemaAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (movieViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(movieViewModel.LogoFile, "Countries");
                }
                MovieEntity movieEntity = _converterHelper.ToMovieEntity(movieViewModel, path, true);
                _context.Add(movieEntity);
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
            return View(movieViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieEntity movieEntity = await _context.Movies.FindAsync(id);
            if (movieEntity == null)
            {
                return NotFound();
            }
            MovieViewModel movieViewModel = _converterHelper.ToMovieViewModel(movieEntity);
            return View(movieViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel movieViewModel)
        {
            if (id != movieViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string path = movieViewModel.LogoPath;
                if (movieViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(movieViewModel.LogoFile, "Movies");
                }
                MovieEntity movieEntity = _converterHelper.ToMovieEntity(movieViewModel, path, false);
                _context.Update(movieEntity);
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
            return View(movieViewModel);
        }

        [Authorize(Roles = "CinemaAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieEntity movieEntity = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
