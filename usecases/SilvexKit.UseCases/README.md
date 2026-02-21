# SilvexKit.UseCases

Defines a minimal use case contract for application-layer handlers.

## Main Type

- `IUseCase<TRequest, TResult>`

## Example

```csharp
public sealed class GetUserUseCase : IUseCase<GetUserRequest, UserDto>
{
    public async Task<Result<UserDto>> Handle(GetUserRequest req, CancellationToken ct)
    {
        // ...
    }
}
```
