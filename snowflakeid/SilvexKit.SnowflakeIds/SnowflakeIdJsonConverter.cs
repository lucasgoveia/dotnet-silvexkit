using System.Text.Json;
using System.Text.Json.Serialization;

namespace SilvexKit.SnowflakeIds;

public class SnowflakeIdJsonConverter : JsonConverter<SnowflakeId>
{
    public override SnowflakeId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var encodeId = reader.GetString();
        return string.IsNullOrEmpty(encodeId)
            ? new SnowflakeId()
            : SnowflakeId.Parse(encodeId, null);
    }

    public override void Write(Utf8JsonWriter writer, SnowflakeId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}