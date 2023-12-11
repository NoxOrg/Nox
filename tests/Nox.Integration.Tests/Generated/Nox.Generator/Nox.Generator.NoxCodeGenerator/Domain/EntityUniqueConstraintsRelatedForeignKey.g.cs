// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;

namespace TestWebApp.Domain;

internal partial class EntityUniqueConstraintsRelatedForeignKey : EntityUniqueConstraintsRelatedForeignKeyBase, IEntityHaveDomainEvents
{
    ///<inheritdoc/>
    public void RaiseCreateEvent()
    {
        InternalRaiseCreateEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseDeleteEvent()
    {
        InternalRaiseDeleteEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseUpdateEvent()
    {
        InternalRaiseUpdateEvent(this);
    }
}
/// <summary>
/// Record for EntityUniqueConstraintsRelatedForeignKey created event.
/// </summary>
internal record EntityUniqueConstraintsRelatedForeignKeyCreated(EntityUniqueConstraintsRelatedForeignKey EntityUniqueConstraintsRelatedForeignKey) :  IDomainEvent, INotification;
/// <summary>
/// Record for EntityUniqueConstraintsRelatedForeignKey updated event.
/// </summary>
internal record EntityUniqueConstraintsRelatedForeignKeyUpdated(EntityUniqueConstraintsRelatedForeignKey EntityUniqueConstraintsRelatedForeignKey) : IDomainEvent, INotification;
/// <summary>
/// Record for EntityUniqueConstraintsRelatedForeignKey deleted event.
/// </summary>
internal record EntityUniqueConstraintsRelatedForeignKeyDeleted(EntityUniqueConstraintsRelatedForeignKey EntityUniqueConstraintsRelatedForeignKey) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing constraints.
/// </summary>
internal abstract partial class EntityUniqueConstraintsRelatedForeignKeyBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number Id { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? TextField { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(EntityUniqueConstraintsRelatedForeignKey entityUniqueConstraintsRelatedForeignKey)
	{
		InternalDomainEvents.Add(new EntityUniqueConstraintsRelatedForeignKeyCreated(entityUniqueConstraintsRelatedForeignKey));
    }
	
	protected virtual void InternalRaiseUpdateEvent(EntityUniqueConstraintsRelatedForeignKey entityUniqueConstraintsRelatedForeignKey)
	{
		InternalDomainEvents.Add(new EntityUniqueConstraintsRelatedForeignKeyUpdated(entityUniqueConstraintsRelatedForeignKey));
    }
	
	protected virtual void InternalRaiseDeleteEvent(EntityUniqueConstraintsRelatedForeignKey entityUniqueConstraintsRelatedForeignKey)
	{
		InternalDomainEvents.Add(new EntityUniqueConstraintsRelatedForeignKeyDeleted(entityUniqueConstraintsRelatedForeignKey));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// EntityUniqueConstraintsRelatedForeignKey for ZeroOrMany EntityUniqueConstraintsWithForeignKeys
    /// </summary>
    public virtual List<EntityUniqueConstraintsWithForeignKey> EntityUniqueConstraintsWithForeignKeys { get; private set; } = new();

    public virtual void CreateRefToEntityUniqueConstraintsWithForeignKeys(EntityUniqueConstraintsWithForeignKey relatedEntityUniqueConstraintsWithForeignKey)
    {
        EntityUniqueConstraintsWithForeignKeys.Add(relatedEntityUniqueConstraintsWithForeignKey);
    }

    public virtual void UpdateRefToEntityUniqueConstraintsWithForeignKeys(List<EntityUniqueConstraintsWithForeignKey> relatedEntityUniqueConstraintsWithForeignKey)
    {
        EntityUniqueConstraintsWithForeignKeys.Clear();
        EntityUniqueConstraintsWithForeignKeys.AddRange(relatedEntityUniqueConstraintsWithForeignKey);
    }

    public virtual void DeleteRefToEntityUniqueConstraintsWithForeignKeys(EntityUniqueConstraintsWithForeignKey relatedEntityUniqueConstraintsWithForeignKey)
    {
        EntityUniqueConstraintsWithForeignKeys.Remove(relatedEntityUniqueConstraintsWithForeignKey);
    }

    public virtual void DeleteAllRefToEntityUniqueConstraintsWithForeignKeys()
    {
        EntityUniqueConstraintsWithForeignKeys.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}