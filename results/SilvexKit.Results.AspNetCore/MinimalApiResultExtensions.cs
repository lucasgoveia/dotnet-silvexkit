using System.Net;
using Microsoft.AspNetCore.Http;

namespace SilvexKit.Results.AspNetCore;

public static class MinimalApiResultExtensions
{
    public static Microsoft.AspNetCore.Http.IResult ToApiResult<T>(this Result<T> result)
    {
        return result.Match(
            success => success.ToApiResult(),
            error => error.ToApiResult()
        );
    }

    public static Microsoft.AspNetCore.Http.IResult ToApiResult(this ErrorResult result)
    {
        return result.Type switch
        {
            ErrorType.Error => TypedResults.StatusCode((int)HttpStatusCode.InternalServerError),
            ErrorType.Forbidden => TypedResults.Forbid(),
            ErrorType.Unauthorized => TypedResults.Unauthorized(),
            ErrorType.Invalid => TypedResults.BadRequest(result.Errors),
            ErrorType.NotFound => TypedResults.NotFound(result.Errors),
            ErrorType.Conflict => TypedResults.Conflict(result.Errors),
            ErrorType.UnprocessableEntity => TypedResults.UnprocessableEntity(result.Errors),
            _ => throw new InvalidOperationException(),
        };
    }

    public static Microsoft.AspNetCore.Http.IResult ToApiResult<T>(this SuccessResult<T> result)
    {
        return result.Type switch
        {
            SuccessType.Accepted => TypedResults.Accepted(result.ResourcePath, result.Value),
            SuccessType.Created => TypedResults.Created(result.ResourcePath, result.Value),
            SuccessType.NoContent => TypedResults.NoContent(),
            SuccessType.Ok => TypedResults.Ok(result.Value),
            _ => throw new InvalidOperationException(),
        };
    }
}