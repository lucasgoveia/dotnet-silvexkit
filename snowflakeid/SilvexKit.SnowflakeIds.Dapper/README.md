# SilvexKit.SnowflakeIds.Dapper

Dapper type handlers for `SnowflakeId`, `SnowflakeId?`, and `SnowflakeId[]`.

## Handlers

- `SnowflakeIdTypeHandler`
- `SnowflakeIdNullableHandler`
- `SnowflakeIdArrayHandler`

## Example

```csharp
using Dapper;
using SilvexKit.SnowflakeIds.Dapper;

SqlMapper.AddTypeHandler(new SnowflakeIdTypeHandler());
SqlMapper.AddTypeHandler(new SnowflakeIdNullableHandler());
SqlMapper.AddTypeHandler(new SnowflakeIdArrayHandler());
```
