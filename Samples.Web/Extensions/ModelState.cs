﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Samples.Web.Extensions
{
    public static class Extensions
    {
        public static void AddToModelState(this List<ValidationFailure> result, ModelStateDictionary modelState)
        {
            if (result.Any())
            {
                foreach (var error in result)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
        }
    }
}
