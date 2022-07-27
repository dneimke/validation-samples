using FluentValidation;
using MediatR;
using Samples.Core.Models;

namespace Samples.Core.Features.Pets
{
    public static class CreatePet
    {
        public class Request : IRequest<Response>
        {
            public Animal Pet { get; set; } = new("", "");
        }

        public class Response
        {

        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator(IValidator<Animal> validator)
            {
                RuleFor(x => x.Pet)
                    .SetValidator(validator);
            }

            
        }

        public class RequestHandler : IRequestHandler<Request, Response>
        {
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var response = new Response();

                return await Task.FromResult(response);
            }
        }
    }
}
