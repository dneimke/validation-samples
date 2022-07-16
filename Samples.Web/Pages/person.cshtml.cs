using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.Core.Models;
using Samples.Web.Extensions;
using System;

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

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _validator.ValidateAsync(Person);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return Page();
            }

            Person = new("", 0);
            return Page();
        }
    }
}
