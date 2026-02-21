# SilvexKit Common Libs

Shared .NET libraries used across Silvex projects.

## Packages

| Package | Folder | Purpose |
| --- | --- | --- |
| `SilvexKit.UnitValue` | `results/SilvexKit.UnitValue` | Unit type (`Unit`) for result patterns and functional flows. |
| `SilvexKit.Results` | `results/SilvexKit.Results` | Result pattern (`Result<T>`, `ErrorResult`, `SuccessResult`). |
| `SilvexKit.Results.AspNetCore` | `results/SilvexKit.Results.AspNetCore` | Minimal API converters from `Result` types to HTTP responses. |
| `SilvexKit.Results.FluentValidation` | `results/SilvexKit.Results.FluentValidation` | Converts `ValidationResult` to `ErrorResult`. |
| `SilvexKit.UseCases` | `usecases/SilvexKit.UseCases` | Use case contract (`IUseCase<TRequest, TResult>`) over `Result<T>`. |
| `SilvexKit.UseCases.DependencyInjection` | `usecases/SilvexKit.UseCases.DependencyInjection` | Assembly scanning registration for `IUseCase<,>` implementations. |
| `SilvexKit.SnowflakeIds` | `snowflakeid/SilvexKit.SnowflakeIds` | Strongly-typed snowflake IDs with Sqids string representation. |
| `SilvexKit.SnowflakeIds.EF` | `snowflakeid/SilvexKit.SnowflakeIds.EF` | EF Core value converter for `SnowflakeId`. |
| `SilvexKit.SnowflakeIds.Dapper` | `snowflakeid/SilvexKit.SnowflakeIds.Dapper` | Dapper type handlers for `SnowflakeId`, nullable IDs, and arrays. |

## Build

```powershell
dotnet build SilvexKit.CommonLibs.slnx -v minimal
```

## Pack

```powershell
dotnet pack SilvexKit.CommonLibs.slnx -c Release
```
