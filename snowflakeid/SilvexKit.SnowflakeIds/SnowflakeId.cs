using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using IdGen;
using Sqids;

namespace SilvexKit.SnowflakeIds;

[JsonConverter(typeof(SnowflakeIdJsonConverter))]
public readonly record struct SnowflakeId(long Value) : IComparable<SnowflakeId>, IParsable<SnowflakeId>
{
    private static readonly DateTimeOffset Epoch = new DateTimeOffset(2023, 08, 01, 0, 0, 0, TimeSpan.Zero);

    private static readonly IdGenerator IdGenerator =
        new(0, new IdGeneratorOptions(new IdStructure(41, 8, 14), new DefaultTimeSource(Epoch)));

    private static readonly SqidsEncoder<long> SqidsEncoder = new(new SqidsOptions()
    {
        Alphabet = "BaFzbTqARLdNpsMUcPXKDoVOGvWhZImCyQeuSljnJgwtHYfrxEik1234567890",
        MinLength = 8
    });

    public static SnowflakeId Empty = new(0);

    public static SnowflakeId NewId() => new(IdGenerator.CreateId());

    public int CompareTo(SnowflakeId other) => Value.CompareTo(other.Value);

    public override string ToString() => SqidsEncoder.Encode(Value);

    public static SnowflakeId Parse(string s, IFormatProvider? provider) => new(SqidsEncoder.Decode(s)[0]);

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out SnowflakeId id)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            id = default;
            return false;
        }

        try
        {
            id = Parse(s, provider);
            return true;
        }
        catch
        {
            id = default;
            return false;
        }
    }

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator <(SnowflakeId left, SnowflakeId right) => left.CompareTo(right) < 0;
    public static bool operator <=(SnowflakeId left, SnowflakeId right) => left.CompareTo(right) <= 0;
    public static bool operator >(SnowflakeId left, SnowflakeId right) => left.CompareTo(right) > 0;
    public static bool operator >=(SnowflakeId left, SnowflakeId right) => left.CompareTo(right) >= 0;

    public static bool operator ==(SnowflakeId? left, SnowflakeId? right)
    {
        if (left.HasValue && right.HasValue)
            return left.Value == right.Value;
        return !left.HasValue && !right.HasValue;
    }

    public static bool operator !=(SnowflakeId? left, SnowflakeId? right)
    {
        return !(left == right);
    }

    public static bool operator <(SnowflakeId? left, SnowflakeId? right)
    {
        if (!left.HasValue) return right.HasValue;
        if (!right.HasValue) return false;
        return left.Value < right.Value;
    }

    public static bool operator <=(SnowflakeId? left, SnowflakeId? right)
    {
        if (!left.HasValue) return !right.HasValue;
        if (!right.HasValue) return false;
        return left.Value <= right.Value;
    }

    public static bool operator >(SnowflakeId? left, SnowflakeId? right)
    {
        if (!left.HasValue) return false;
        if (!right.HasValue) return true;
        return left.Value > right.Value;
    }

    public static bool operator >=(SnowflakeId? left, SnowflakeId? right)
    {
        if (!left.HasValue) return !right.HasValue;
        if (!right.HasValue) return true;
        return left.Value >= right.Value;
    }

    public static explicit operator long(SnowflakeId id) => id.Value;
    public static explicit operator string(SnowflakeId id) => id.ToString();
    public static explicit operator SnowflakeId(long value) => new(value);
}
