namespace E.S.Api.Helpers.Exceptions
{
    public interface IApiException
    {
        string ErrorCode { get; }
        string UserMessage { get; }
    }
}