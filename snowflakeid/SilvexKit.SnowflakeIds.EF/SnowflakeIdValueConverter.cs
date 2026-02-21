using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SilvexKit.SnowflakeIds.EF;

public class SnowflakeIdValueConverter() : ValueConverter<SnowflakeId, long>(id => id.Value,
    value => new SnowflakeId(value));
