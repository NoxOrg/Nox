using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="AutoNumber"/> type and value object.
/// </summary>
public sealed class AutoNumber : ValueObject<long, AutoNumber>
{
    public AutoNumber()
    {
        Value = 0;
    }

    /// <summary>
    /// <see cref="AutoNumber"/> object can only be created with <see cref="ValueObject{T,TValueObject}.FromDatabase"/>.
    /// </summary>
    public new static AutoNumber From(long _) => throw new InvalidOperationException($"{nameof(AutoNumber)} can only be created with {nameof(FromDatabase)}.");
    public static AutoNumber From(long _, AutoNumberTypeOptions __) => throw new InvalidOperationException($"{nameof(AutoNumber)} can only be created with {nameof(FromDatabase)}.");
}