using System;
using E.S.Api.Helpers.Enums;
using E.S.Api.Helpers.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace E.S.Api.Helpers.Extensions
{
    public static class ApiActionResultExtensions
    {
        public static IActionResult ToActionResult(this ApiActionResult result)
        {
            return ((IConvertToActionResult) ToExplicitActionResult(result)).Convert();
        }

        public static IActionResult ToActionResult<T>(this ApiActionResult<T> result)
        {
            return ((IConvertToActionResult) ToExplicitActionResult(result)).Convert();
        }

        private static ActionResult<ApiActionResult<T>> ToExplicitActionResult<T>(this ApiActionResult<T> result)
        {
            return result.ResultType switch
            {
                ApiResultTypeEnum.Success => result,
                ApiResultTypeEnum.Failed => new BadRequestObjectResult(result),
                ApiResultTypeEnum.Unauthorized => new UnauthorizedResult(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static ActionResult<ApiActionResult> ToExplicitActionResult(this ApiActionResult result)
        {
            return result.ResultType switch
            {
                ApiResultTypeEnum.Success => result,
                ApiResultTypeEnum.Failed => new BadRequestObjectResult(result),
                ApiResultTypeEnum.Unauthorized => new UnauthorizedResult(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}