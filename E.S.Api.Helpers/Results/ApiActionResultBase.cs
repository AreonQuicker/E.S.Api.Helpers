using System.Collections.Generic;
using System.Linq;
using E.S.Api.Helpers.Enums;

namespace E.S.Api.Helpers.Results
{
    public abstract class ApiActionResultBase
    {
        protected ApiActionResultBase(ApiResultTypeEnum resultType, string message)
        {
            Errors = new List<string>();
            ResultType = resultType;
            Message = message;
        }

        public ApiResultTypeEnum ResultType { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string ErrorCode { get; set; }

        public bool Failed => (Errors?.Any() ?? false) || ResultType == ApiResultTypeEnum.Failed;
    }
}