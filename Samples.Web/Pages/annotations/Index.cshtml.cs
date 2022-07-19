using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.Core.Models;

namespace Samples.Web.Pages.annotations
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Car? Vehicle { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            TempData["Message"] = "Saved successfully!";
            return RedirectToPage("/annotations/index");
        }
    }
}
