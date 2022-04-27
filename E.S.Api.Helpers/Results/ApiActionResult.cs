using System.Collections.Generic;
using System.Linq;
using E.S.Api.Helpers.Enums;

namespace E.S.Api.Helpers.Results
{
    public class ApiActionResult<T> : ApiActionResultBase
    {
        private ApiActionResult(T data, string message = null) : base(ApiResultTypeEnum.Success, message)
        {
            Data = data;
        }

        private ApiActionResult(T data, string message, params string[] errors) : base(ApiResultTypeEnum.Failed,
            message)
        {
            Data = data;
            Errors = errors?.ToList() ?? new List<string>();
            if (Errors.Any())
                ResultType = ApiResultTypeEnum.Failed;
        }

        public T Data { get; set; }

        public static ApiActionResult<T> MakeFailed(T data, string erroCode, string message, params string[] errors)
        {
            return new ApiActionResult<T>(data, message, message);
        }

        public static ApiActionResult<T> MakeSuccess(T data, string message)
        {
            return new ApiActionResult<T>(data);
        }
    }

    public class ApiActionResult : ApiActionResultBase
    {
        private ApiActionResult(string message = null) : base(ApiResultTypeEnum.Success, message)
        {
        }

        private ApiActionResult(string errorCode, string message, params string[] errors) : base(
            ApiResultTypeEnum.Failed, message)
        {
            ErrorCode = errorCode;
            Errors = errors?.ToList() ?? new List<string>();
            if (Errors.Any())
                ResultType = ApiResultTypeEnum.Failed;
        }

        public static ApiActionResult MakeFailed(string errorCode, string message, params string[] errors)
        {
            return new ApiActionResult(errorCode, message, errors);
        }

        public static ApiActionResult MakeSuccess(string message)
        {
            return new ApiActionResult(message);
        }
    }
}