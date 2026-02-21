using System.Linq;
using FluentValidation.Results;

namespace SilvexKit.Results.FluentValidation;

public static class FluentValidationExtensions
{
    public static ErrorResult ToErrorResult(this ValidationResult validationResult)
    {
        var errors = validationResult.Errors.Select(x => new AppError
        {
            ErrorCode = x.ErrorCode,
            ErrorMessage = x.ErrorMessage
        }).ToArray();

        return Result.Invalid(errors);
    }
}
