namespace Nox.Domain;

/// <summary>
/// Entities whose updates need to be handled with optimistic concurrency
/// </summary>
public interface IConcurrent
{
    /// <summary>
    /// Gets the entity tag.
    /// </summary>
    Types.Guid Etag { get; }
}
