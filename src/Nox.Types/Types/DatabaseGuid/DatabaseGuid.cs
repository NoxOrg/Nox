using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="DatabaseGuid"/> type and value object.
/// </summary>
public sealed class DatabaseGuid : ValueObject<System.Guid, DatabaseGuid>
{
    public DatabaseGuid()
    {
        Value = System.Guid.Empty;
    }

    /// <summary>
    /// <see cref="DatabaseGuid"/> object can only be created with <see cref="ValueObject{T,TValueObject}.FromDatabase"/>.
    /// </summary>
    public new static DatabaseGuid From(System.Guid _) => throw new InvalidOperationException($"{nameof(DatabaseGuid)} can only be created with {nameof(FromDatabase)}.");
}