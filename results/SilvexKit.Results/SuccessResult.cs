namespace SilvexKit.Results;

public record SuccessResult<T>
{
    internal SuccessResult() {}
    public T Value { get; init; } = default!;
    public string? ResourcePath { get; init; }
    public SuccessType Type { get; init; }


    public static implicit operator T(SuccessResult<T> result) => result.Value;
    public static implicit operator SuccessResult<T>(T value) => new() { Value = value, Type = SuccessType.Ok };
}

public sealed record SuccessResult : SuccessResult<UnitValue.Unit>
{
    
}
