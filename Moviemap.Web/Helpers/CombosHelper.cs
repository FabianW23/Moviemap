using Microsoft.AspNetCore.Mvc.Rendering;
using Moviemap.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;
        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboBrands()
        {
            List<SelectListItem> list = _context.Brands
                 .Select(t => new SelectListItem
                 {
                     Text = t.Name,
                     Value = $"{t.Id}"
                 })
                 .OrderBy(t => t.Text)
                 .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a brand...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboCinemas(string userEmail)
        {
            List<SelectListItem> list = _context.Cinemas.Where(c => c.User.Email == userEmail)
                .Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a cinema...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboMovies()
        {
            List<SelectListItem> list = _context.Movies
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"
                })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a movie...]",
                Value = "0"
            });

            return list;
        }
    }
}
