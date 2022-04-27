using E.S.Api.Helpers.Extensions;
using E.S.Api.Helpers.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E.S.Api.Helpers.Filters
{
    public class ApiActionResultFilterAttribute<T> : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
                return;

            if (!(context.Result is ObjectResult objectResult))
                return;

            context.Result = objectResult.Value switch
            {
                null => ApiActionResult<T>.MakeSuccess(default, null).ToActionResult(),
                T data => ApiActionResult<T>.MakeSuccess(data, null).ToActionResult(),
                _ => context.Result
            };
        }
    }
}