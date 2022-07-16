using FluentValidation;
using FluentValidation.Results;
using System.Reflection;

// credit: https://khalidabuhakmeh.com/minimal-api-validation-with-fluentvalidation

namespace Samples.Core.Validation
{
    public class Validated<T>
    {
        public T Value { get; }
        private ValidationResult Validation { get; }

        public bool IsValid => Validation.IsValid;

        private Validated(T value, ValidationResult validation)
        {
            Value = value;
            Validation = validation;
        }

        public IDictionary<string, string[]> Errors =>
            Validation.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(x => x.Key, x => x.Select(e => e.ErrorMessage).ToArray());

        public void Deconstruct(out bool isValid, out T value)
        {
            isValid = IsValid;
            value = Value;
        }

        public static async ValueTask<Validated<T>> BindAsync(HttpContext context, ParameterInfo parameter)
        {
            var value = await context.Request.ReadFromJsonAsync<T>();

            if (value == null)
            {
                throw new ArgumentNullException(parameter.Name);
            }

            var validator = context.RequestServices.GetRequiredService<IValidator<T>>();
            var results = await validator.ValidateAsync(value);

            return new Validated<T>(value, results);
        }
    }
}
