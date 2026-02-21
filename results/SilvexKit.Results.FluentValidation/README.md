# SilvexKit.Results.FluentValidation

Converts FluentValidation failures into `SilvexKit.Results.ErrorResult`.

## Example

```csharp
using FluentValidation.Results;
using SilvexKit.Results.FluentValidation;

ValidationResult validation = new();
var error = validation.ToErrorResult();
```
