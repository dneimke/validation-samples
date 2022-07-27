using FluentValidation;

namespace Samples.Core.Models
{
    public record Animal(string? Name, string? Species);

    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(25)
                .WithMessage("{PropertyName} cannot exceed {MaxLength} characters")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must be at least {MinLength} characters")
                .NotEmpty();

            RuleFor(x => x.Species)
                .MaximumLength(25)
                .WithMessage("{PropertyName} cannot exceed {MaxLength} characters")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must be at least {MinLength} characters")
                .NotEmpty();
        }
    }
}
