using FluentValidation;
using MediatR;
using Samples.Core.Models;

namespace Samples.Core.Features.People
{
    public static class CreatePerson
    {
        public class Request : IRequest<Response>
        {
            public Person Person { get; set; } = new("", 0);
        }

        public class Response
        {

        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator(IValidator<Person> validator)
            {
                RuleFor(x => x.Person)
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
