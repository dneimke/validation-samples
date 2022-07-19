# Fluent

These examples show how to use FluentValidation and ModelState to validate business objects.

## Pre-Reqs

- Install FluentValidation
- Register Validators

```csharp
// Program.cs
builder.Services.AddValidatorsFromAssemblyContaining<Marker>();
```

## Fluent/Manual

In this example, we inject a validator and manually invoke it from within our page handler 