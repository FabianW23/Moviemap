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
    public class BrandController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public BrandController(DataContext context, IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BrandEntity brandEntity = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            BrandViewModel brandViewModel = _converterHelper.ToBrandViewModel(brandEntity);
            if (brandEntity == null)
            {
                return NotFound();
            }

            return View(brandViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (brandViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(brandViewModel.LogoFile, "Brands");
                }
                BrandEntity brandEntity = _converterHelper.ToBrandEntity(brandViewModel, path, true);
                _context.Add(brandEntity);
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
            return View(brandViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BrandEntity brandEntity = await _context.Brands.FindAsync(id);
            if (brandEntity == null)
            {
                return NotFound();
            }
            BrandViewModel brandViewModel = _converterHelper.ToBrandViewModel(brandEntity);
            return View(brandViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BrandViewModel brandViewModel)
        {
            if (id != brandViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string path = brandViewModel.LogoPath;
                if (brandViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(brandViewModel.LogoFile, "Brands");
                }
                BrandEntity brandEntity = _converterHelper.ToBrandEntity(brandViewModel, path, false);
                _context.Update(brandEntity);
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
            return View(brandViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BrandEntity brandEntity = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brandEntity == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brandEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
