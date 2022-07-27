using FluentValidation;
using MediatR;
using Samples.Core;
using Samples.Core.Models;
using Samples.Core.Validation;
using static Microsoft.AspNetCore.Http.Results;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMediatR(typeof(Marker));
builder.Services.AddValidatorsFromAssemblyContaining<Marker>();


builder.Services.Decorate(typeof(IRequestHandler<,>), typeof(ValidatorWrapper<,>));


// TODO: consider using Behaviors (https://lurumad.github.io/cross-cutting-concerns-in-asp-net-core-with-meaditr)


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/foo", () => "Hello Foo");

app.MapPost("/post-person", (Validated<Person> req) =>
{
    var (isValid, value) = req;

    return isValid
    ? RedirectToRoute("/person", value)
    : ValidationProblem(req.Errors);
});

app.Run();
