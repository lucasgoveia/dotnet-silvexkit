using System;
using System.Collections.Generic;
using System.Linq;

namespace SilvexKit.Results;

public record Result<T> : IResult
{
    private readonly SuccessResult<T>? _successResult;
    private readonly ErrorResult? _errorResult;
    public bool IsSuccess { get; }

    protected Result(SuccessResult<T> successResult)
    {
        _successResult = successResult;
        IsSuccess = true;
    }

    protected Result(ErrorResult errorResult)
    {
        _errorResult = errorResult;
        IsSuccess = false;
    }


    public static implicit operator Result<T>(T value) => new(Result.Ok(value));

    public static implicit operator Result<T>(SuccessResult<T> value)
    {
        return new(value);
    }


    public static implicit operator Result<T>(ErrorResult value)
    {
        return new(value);
    }

    public static implicit operator Result(Result<T> value)
    {
        return value.Match(success => new Result(Result.Success(success.Type)),
            error => new Result(error));
    }

    public TE Match<TE>(Func<SuccessResult<T>, TE> successHandler, Func<ErrorResult, TE> errorHandler)
    {
        return IsSuccess
            ? successHandler(_successResult!)
            : errorHandler(_errorResult!);
    }


    public TE MatchObject<TE>(Func<SuccessResult<object>, TE> successHandler, Func<ErrorResult, TE> errorHandler)
    {
        return IsSuccess
            ? successHandler(Result.Success<object>(_successResult!.Value!, _successResult.Type))
            : errorHandler(_errorResult!);
    }

    public Result<TE> Map<TE>(Func<T, TE> mapper)
    {
        return IsSuccess
            ? Result.Ok(mapper(_successResult!))
            : _errorResult!;
    }


    public ErrorResult? AsError()
    {
        return _errorResult;
    }


    public bool TryGetValue(out T value)
    {
        if (IsSuccess)
        {
            value = _successResult!.Value;
            return true;
        }

        value = default!;
        return false;
    }

    #region Errors

    public static ErrorResult Error(params AppError[] appErrors)
    {
        return new ErrorResult { Errors = appErrors.ToList(), Type = ErrorType.Error };
    }


    public static ErrorResult Error(string errorMessage)
    {
        return new ErrorResult { Errors = new List<AppError> { new(errorMessage) }, Type = ErrorType.Error };
    }

    public static ErrorResult UnprocessableEntity(string errorMessage)
    {
        return new ErrorResult { Errors = new List<AppError> { new(errorMessage) }, Type = ErrorType.UnprocessableEntity };
    }

    public static ErrorResult Invalid(string message)
    {
        return new ErrorResult { Errors = new List<AppError> { new(message) }, Type = ErrorType.Invalid };
    }
    
    
    public static ErrorResult Invalid(AppError appError)
    {
        return new ErrorResult
            { Errors = new List<AppError>(new[] { appError }), Type = ErrorType.Invalid };
    }

    public static ErrorResult Invalid()
    {
        return new ErrorResult
            { Errors = new List<AppError>(), Type = ErrorType.Invalid };
    }

    public static ErrorResult Invalid(IEnumerable<AppError> appErrors)
    {
        return new ErrorResult { Errors = appErrors.ToList(), Type = ErrorType.Invalid };
    }


    public static ErrorResult NotFound()
    {
        return new ErrorResult { Errors = Array.Empty<AppError>(), Type = ErrorType.NotFound };
    }


    public static ErrorResult Forbidden()
    {
        return new ErrorResult { Errors = Array.Empty<AppError>(), Type = ErrorType.Forbidden };
    }


    public static ErrorResult Unauthorized()
    {
        return new ErrorResult { Errors = Array.Empty<AppError>(), Type = ErrorType.Unauthorized };
    }


    public static ErrorResult Conflict()
    {
        return new ErrorResult { Errors = Array.Empty<AppError>(), Type = ErrorType.Conflict };
    }

    #endregion

    #region Success

    internal static SuccessResult Success(SuccessType type)
    {
        return new SuccessResult { Value = UnitValue.Unit.Default, Type = type };
    }

    internal static SuccessResult<TV> Success<TV>(TV value, SuccessType type)
    {
        return new SuccessResult<TV> { Value = value, Type = type };
    }


    public static SuccessResult Ok()
    {
        return Success(SuccessType.Ok);
    }

    public static SuccessResult<TV> Ok<TV>(TV value)
    {
        return Success(value, SuccessType.Ok);
    }


    public static SuccessResult Accepted()
    {
        return Success(SuccessType.Accepted);
    }


    public static SuccessResult Created()
    {
        return Success(SuccessType.Created);
    }

    public static SuccessResult<TV> Created<TV>(TV value)
    {
        return Success(value, SuccessType.Created);
    }

    public static SuccessResult NoContent()
    {
        return Success(SuccessType.NoContent);
    }

    #endregion
}

public sealed record Result : Result<UnitValue.Unit>
{
    internal Result(SuccessResult successResult) : base(successResult)
    {
    }

    internal Result(ErrorResult errorResult) : base(errorResult)
    {
    }

    public static implicit operator Result(ErrorResult value)
    {
        return new(value);
    }

    public static implicit operator Result(SuccessResult value)
    {
        return new(value);
    }
}
