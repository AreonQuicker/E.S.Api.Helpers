using System;

namespace E.S.Api.Helpers.Exceptions
{
    public class ApiNotFoundException : ApiException
    {
        public ApiNotFoundException(string message, string errorCode = null)
            : base(message, null, errorCode)
        {
        }

        public ApiNotFoundException(string message, string errorCode = null, Exception innerException = null)
            : base(message, null, errorCode, innerException)
        {
        }

        public ApiNotFoundException(string name, object key, string errorCode = null)
            : base($"Entity \"{name}\" ({key}) was not found.", null, errorCode)
        {
        }
    }
}