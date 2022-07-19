using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.Core.Models;
using Samples.Web.Extensions;

namespace Samples.Web.Pages
{
    public class personModel : PageModel
    {
        private readonly IValidator<Person> _validator;

        public personModel(IValidator<Person> validator)
        {
            _validator = validator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person? Person { get; set; }

        public IActionResult OnPost()
        {
            var result = _validator.Validate(Person);

            if(!result.IsValid)
            {
                result.Errors.AddToModelState(ModelState);
                return Page();
            }

            TempData["Message"] = "Saved successfully!";
            return RedirectToPage("/fluent/manual");
        }
    }
}
