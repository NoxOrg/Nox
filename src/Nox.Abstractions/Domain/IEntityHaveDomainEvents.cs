namespace Nox.Domain;

/// <summary>
/// Represents an interface for entities that can generate and manage domain events.
/// </summary>
public interface IEntityHaveDomainEvents
{
    /// <summary>
    /// Gets a collection of domain events associated with the entity.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Raises a domain event when the entity is created.
    /// </summary>
    void RaiseCreateEvent();

    /// <summary>
    /// Raises a domain event when the entity is deleted.
    /// </summary>
    void RaiseDeleteEvent();

    /// <summary>
    /// Raises a domain event when the entity is updated.
    /// </summary>
    void RaiseUpdateEvent();

    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    void ClearDomainEvents();
}