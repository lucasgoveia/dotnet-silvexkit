using SilvexKit.Results;

namespace SilvexKit.UseCases;

public interface IUseCase<in TRequest, TResult>
{
    Task<Result<TResult>> Handle(TRequest req, CancellationToken ct);
}
