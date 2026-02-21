using System.Data;
using Dapper;

namespace SilvexKit.SnowflakeIds.Dapper;

public class SnowflakeIdTypeHandler : SqlMapper.TypeHandler<SnowflakeId>
{
    public override void SetValue(IDbDataParameter parameter, SnowflakeId value)
    {
        parameter.Value = value.Value;
    }

    public override SnowflakeId Parse(object? value)
    {
        var idLong = (long?)value;
        return !idLong.HasValue
            ? default
            : new SnowflakeId(idLong.Value);
    }
}

public class SnowflakeIdArrayHandler : SqlMapper.TypeHandler<SnowflakeId[]>
{
    public override void SetValue(IDbDataParameter parameter, SnowflakeId[]? value)
    {
        parameter.Value = value?.Select(id => id.Value).ToArray();
    }

    public override SnowflakeId[] Parse(object value)
    {
        var longArray = (long[])value;
        return longArray.Select(l => new SnowflakeId(l)).ToArray();
    }
}

public class SnowflakeIdNullableHandler : SqlMapper.TypeHandler<SnowflakeId?>
{
    public override void SetValue(IDbDataParameter parameter, SnowflakeId? value)
    {
        parameter.Value = value.HasValue
            ? value.Value.Value
            : DBNull.Value;
        parameter.DbType = DbType.Int64;
    }

    public override SnowflakeId? Parse(object? value)
    {
        var idLong = (long?)value;
        return !idLong.HasValue
            ? default
            : new SnowflakeId(idLong.Value);
    }
}