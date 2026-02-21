# SilvexKit.UseCases.DependencyInjection

Registers `IUseCase<TRequest, TResult>` implementations from an assembly.

## Main API

- `IServiceCollection AddUseCasesFromAssembly(Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped)`

## Example

```csharp
using SilvexKit.UseCases.DependencyInjection;

builder.Services.AddUseCasesFromAssembly(typeof(GetUserUseCase).Assembly);
```
