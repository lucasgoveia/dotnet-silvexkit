namespace SilvexKit.Results;

public record AppError
{
    public AppError()
    {
    }

    public AppError(string errorMessage, string errorCode = "")
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; init; } = string.Empty;
    public string ErrorCode { get; init; } = string.Empty;
}
