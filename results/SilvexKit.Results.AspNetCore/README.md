# SilvexKit.Results.AspNetCore

Adds Minimal API extensions to convert `SilvexKit.Results` results into `IResult` HTTP responses.

## Example

```csharp
using SilvexKit.Results;
using SilvexKit.Results.AspNetCore;

Result<string> result = Result.Ok("hello");
var apiResult = result.ToApiResult();
```
