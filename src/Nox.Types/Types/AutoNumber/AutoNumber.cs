namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="AutoNumber"/> type and value object.
/// </summary>
public sealed class AutoNumber : ValueObject<uint, AutoNumber>
{
    public AutoNumber()
    {
        Value = 0;
    }

    /// <summary>
    /// Creates a <see cref="AutoNumber"/> object with the initial value of <paramref name="value"/>.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="AutoNumber"/> object.</returns>
    public new static AutoNumber From(uint value) => new() { Value = value };

    /// <summary>
    /// Gets the current Value incremented by one.
    /// </summary>
    /// <returns>The current value incremented by one.</returns>
    public uint GetNext() => ++Value;
}