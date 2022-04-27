using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E.S.Api.Helpers.Models
{
    public class ValidationResult
    {
        public ValidationResult(ModelStateDictionary modelState)
        {
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }

        public List<ValidationError> Errors { get; set; }
    }
}