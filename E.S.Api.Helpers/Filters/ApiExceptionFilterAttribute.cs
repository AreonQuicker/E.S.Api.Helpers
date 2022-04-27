using System.Linq;
using E.S.Api.Helpers.Exceptions;
using E.S.Api.Helpers.Extensions;
using E.S.Api.Helpers.Results;
using E.S.Logging.Enums;
using E.S.Logging.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace E.S.Api.Helpers.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly string _loggedInUsername;
        private readonly ILogger _logger;

        public ApiExceptionFilterAttribute(IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType()
                .FullName);
            _loggedInUsername = httpContextAccessor.ToUserName();
        }

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            _logger.LogErrorOperation(LoggerStatusEnum.Error,
                "Api Global",
                null,
                null,
                _loggedInUsername,
                exception.Message,
                exception);

            if (exception.GetType().GetInterfaces().Any(a => a == typeof(IApiException)))
            {
                var ex = (IApiException) exception;

                context.Result
                    = ApiActionResult
                        .MakeFailed(ex.ErrorCode, ex.UserMessage ?? exception.Message,
                            ex.UserMessage ?? exception.Message)
                        .ToActionResult();

                context.ExceptionHandled = true;

                return;
            }


            context.Result
                = ApiActionResult
                    .MakeFailed(null,
                        exception.Message, exception.Message)
                    .ToActionResult();

            context.ExceptionHandled = true;
        }
    }
}