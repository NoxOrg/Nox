using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="DatabaseNumber"/> type and value object.
/// </summary>
public sealed class DatabaseNumber : ValueObject<ulong, DatabaseNumber>
{
    public DatabaseNumber()
    {
        Value = 0;
    }

    /// <summary>
    /// <see cref="DatabaseNumber"/> object can only be created with <see cref="ValueObject{T,TValueObject}.FromDatabase"/>.
    /// </summary>
    public new static DatabaseNumber From(ulong _) => throw new InvalidOperationException($"{nameof(DatabaseNumber)} can only be created with {nameof(FromDatabase)}.");
}