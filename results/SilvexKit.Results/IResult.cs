using System;

namespace SilvexKit.Results;

public interface IResult 
{
    public TE MatchObject<TE>(Func<SuccessResult<object>, TE> successHandler, Func<ErrorResult, TE> errorHandler);
}
