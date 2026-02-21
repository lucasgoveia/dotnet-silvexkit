using System;
using System.Collections.Generic;

namespace SilvexKit.Results;

public sealed record ErrorResult
{
    public ErrorType Type { get; init; }
    public IList<AppError> Errors { get; init; } = Array.Empty<AppError>();
    
}
