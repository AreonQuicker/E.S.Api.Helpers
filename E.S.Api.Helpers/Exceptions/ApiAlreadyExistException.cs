using System;

namespace E.S.Api.Helpers.Exceptions
{
    public class ApiAlreadyExistException : ApiException
    {
        public ApiAlreadyExistException(string message, string errorCode = null)
            : base(message, null, errorCode)
        {
        }

        public ApiAlreadyExistException(string message, string errorCode = null, Exception innerException = null)
            : base(message, null, errorCode, innerException)
        {
        }

        public ApiAlreadyExistException(string name, object key, string errorCode = null)
            : base($"Entity \"{name}\" ({key}) already exist.", null, errorCode)
        {
        }
    }
}