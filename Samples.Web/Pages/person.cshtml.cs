using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Samples.Core.Features.People;
using Samples.Core.Models;
using Samples.Web.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Samples.Web.Pages
{
    public class personModel : PageModel
    {
        private readonly IValidator<Person> _validator;
        private readonly IMediator _mediator;

        public personModel(IValidator<Person> validator, IMediator mediator)
        {
            _validator = validator;
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person? Person { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var result = await _mediator.Send(new CreatePerson.Request { Person = Person });
                return Page();
            }
            catch(FluentValidation.ValidationException ex)
{
                var errors = ex.Errors.ToList();
                errors.AddToModelState(ModelState);
            }

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var result = await _validator.ValidateAsync(Person);

        //    if (!result.IsValid)
        //    {
        //        result.AddToModelState(ModelState);
        //        return Page();
        //    }

        //    Person = new("", 0);
        //    return Page();
        //}
    }
}
