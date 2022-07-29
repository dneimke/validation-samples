# Validation Samples

The purpose of this project is to demonstrate various techniques and methods for using [FluentValidation](https://docs.fluentvalidation.net/en/latest/) to validate business objects.

This is an examples-based Visual Studio solution where each type of example is surfaced through an associated folder. Each folder has an associated `readme.md` that provides additional technical information about the example.

```
Solution
  - readme.md
  /example-1
    - readme.md
    - example web page 
  /example-2
    - readme.md
    - example web page 
```

The example scenarios are:

- Using data annotations and model state
- Create a fluent-validator to validate a business object
- Invoke a fluent-validator manually and map validation errors to model state
- Implement validation is as a cross-cutting concern using decoration
- Implement validation is as a cross-cutting concern using MediatR pipeline behaviours
- Introduce ExceptionFilters for handling validation errors as a cross-cutting concern
- Introduce unit tests to test validation logic for business rules
