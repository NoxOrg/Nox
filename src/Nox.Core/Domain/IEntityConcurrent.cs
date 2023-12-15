namespace Nox.Domain;

/// <summary>
/// Entities whose updates need to be handled with optimistic concurrency
/// </summary>
public interface IEntityConcurrent
{
    /// <summary>
    /// Gets the entity tag.
    /// </summary>
    System.Guid Etag { get; }
}
