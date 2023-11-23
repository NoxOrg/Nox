using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="ReferenceNumber"/> type and value object.
/// </summary>
public sealed class ReferenceNumber : ValueObject<string, ReferenceNumber>
{
    public ReferenceNumber()
    {
        Value = string.Empty;
    }

    /// <summary>
    /// <see cref="ReferenceNumber"/> object can only be created with <see cref="ValueObject{T,TValueObject}.FromDatabase"/>.
    /// </summary>
    public new static ReferenceNumber From(string _) => throw new InvalidOperationException($"{nameof(ReferenceNumber)} can only be created with {nameof(FromDatabase)}.");
    public static ReferenceNumber From(string _, ReferenceNumberTypeOptions __) => throw new InvalidOperationException($"{nameof(ReferenceNumber)} can only be created with {nameof(FromDatabase)}.");
}