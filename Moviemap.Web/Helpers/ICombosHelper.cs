using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Moviemap.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCinemas(string userEmail);

        IEnumerable<SelectListItem> GetComboMovies();
    }
}
