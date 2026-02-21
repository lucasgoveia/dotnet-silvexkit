# SilvexKit.Results

Implements a lightweight result pattern with explicit success and error flows.

## Main Types

- `Result<T>` and `Result`
- `SuccessResult<T>`
- `ErrorResult`
- `AppError`

## Example

```csharp
using SilvexKit.Results;

Result<string> result = Result.Ok("ok");

var message = result.Match(
    success => success.Value,
    error => error.Errors.FirstOrDefault()?.ErrorMessage ?? "unknown");
```
