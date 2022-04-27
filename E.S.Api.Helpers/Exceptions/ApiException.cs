using System;

namespace E.S.Api.Helpers.Exceptions
{
    public class ApiException : Exception, IApiException
    {
        public ApiException(string message, string userMessage = null, string errorCode = null,
            Exception innerException = null)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            UserMessage = userMessage ?? message;
        }

        public string ErrorCode { get; }
        public string UserMessage { get; }
    }
}