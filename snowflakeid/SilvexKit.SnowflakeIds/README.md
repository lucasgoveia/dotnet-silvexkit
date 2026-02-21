# SilvexKit.SnowflakeIds

Strongly-typed snowflake IDs backed by `long`, with Sqids encoding for string representation.

## Example

```csharp
using SilvexKit.SnowflakeIds;

var id = SnowflakeId.NewId();
string encoded = id.ToString();
var parsed = SnowflakeId.Parse(encoded, null);
```
