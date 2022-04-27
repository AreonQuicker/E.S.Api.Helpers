using E.S.Api.Helpers.Extensions;
using E.S.Api.Helpers.Models;
using E.S.Api.Helpers.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E.S.Api.Helpers.Filters
{
    public class ApiValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            context.Result
                = ApiActionResult<ValidationResult>
                    .MakeFailed(new ValidationResult(context.ModelState), null, "Validation failed")
                    .ToActionResult();

            base.OnActionExecuting(context);
        }
    }
}