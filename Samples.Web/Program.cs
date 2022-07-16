using FluentValidation;
using Samples.Core;
using Samples.Core.Models;
using Samples.Core.Validation;
using static Microsoft.AspNetCore.Http.Results;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddValidatorsFromAssemblyContaining<Marker>();

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
