using FluentValidation;

namespace Samples.Core.Models
{
    public record Person(string? Name, int? Age);

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).NotEmpty().GreaterThan(0);
        }
    }
}
