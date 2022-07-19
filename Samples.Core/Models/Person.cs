using FluentValidation;

namespace Samples.Core.Models
{
    public record Person(string? Name, int? Age);

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).NotEmpty()
                .InclusiveBetween(5, 65)
                .WithMessage("The person's age must be between 5 and 65.");
        }
    }
}
