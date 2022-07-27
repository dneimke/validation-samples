using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.Core.Features.Pets;
using Samples.Core.Models;
using Samples.Web.Extensions;

namespace Samples.Web.Pages.cross_cutting
{
    public class mediatorModel : PageModel
    {
        private readonly IMediator _mediator;

        public mediatorModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Animal Pet { get; set; } = new("", "");

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var result = await _mediator.Send(new CreatePet.Request { Pet = Pet });
                
                TempData["Message"] = "Saved successfully!";
                return RedirectToPage("/cross-cutting/mediator");
            }
            catch(ValidationException ex)
            {
                ex.Errors.ToList().AddToModelState(ModelState);
                return Page();
            }
            
        }
    }
}
