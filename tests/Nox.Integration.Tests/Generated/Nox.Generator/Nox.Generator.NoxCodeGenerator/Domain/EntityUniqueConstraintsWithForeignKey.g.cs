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

internal partial class EntityUniqueConstraintsWithForeignKey : EntityUniqueConstraintsWithForeignKeyBase, IEntityHaveDomainEvents
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
/// Record for EntityUniqueConstraintsWithForeignKey created event.
/// </summary>
internal record EntityUniqueConstraintsWithForeignKeyCreated(EntityUniqueConstraintsWithForeignKey EntityUniqueConstraintsWithForeignKey) :  IDomainEvent, INotification;
/// <summary>
/// Record for EntityUniqueConstraintsWithForeignKey updated event.
/// </summary>
internal record EntityUniqueConstraintsWithForeignKeyUpdated(EntityUniqueConstraintsWithForeignKey EntityUniqueConstraintsWithForeignKey) : IDomainEvent, INotification;
/// <summary>
/// Record for EntityUniqueConstraintsWithForeignKey deleted event.
/// </summary>
internal record EntityUniqueConstraintsWithForeignKeyDeleted(EntityUniqueConstraintsWithForeignKey EntityUniqueConstraintsWithForeignKey) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing constraints with Foreign Key.
/// </summary>
internal abstract partial class EntityUniqueConstraintsWithForeignKeyBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; set;} = null!;
         /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? TextField { get; set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number SomeUniqueId { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(EntityUniqueConstraintsWithForeignKey entityUniqueConstraintsWithForeignKey)
	{
		InternalDomainEvents.Add(new EntityUniqueConstraintsWithForeignKeyCreated(entityUniqueConstraintsWithForeignKey));
    }
	
	protected virtual void InternalRaiseUpdateEvent(EntityUniqueConstraintsWithForeignKey entityUniqueConstraintsWithForeignKey)
	{
		InternalDomainEvents.Add(new EntityUniqueConstraintsWithForeignKeyUpdated(entityUniqueConstraintsWithForeignKey));
    }
	
	protected virtual void InternalRaiseDeleteEvent(EntityUniqueConstraintsWithForeignKey entityUniqueConstraintsWithForeignKey)
	{
		InternalDomainEvents.Add(new EntityUniqueConstraintsWithForeignKeyDeleted(entityUniqueConstraintsWithForeignKey));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// EntityUniqueConstraintsWithForeignKey for ExactlyOne EntityUniqueConstraintsRelatedForeignKeys
    /// </summary>
    public virtual EntityUniqueConstraintsRelatedForeignKey EntityUniqueConstraintsRelatedForeignKey { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity EntityUniqueConstraintsRelatedForeignKey
    /// </summary>
    public Nox.Types.Number EntityUniqueConstraintsRelatedForeignKeyId { get; set; } = null!;

    public virtual void CreateRefToEntityUniqueConstraintsRelatedForeignKey(EntityUniqueConstraintsRelatedForeignKey relatedEntityUniqueConstraintsRelatedForeignKey)
    {
        EntityUniqueConstraintsRelatedForeignKey = relatedEntityUniqueConstraintsRelatedForeignKey;
    }

    public virtual void DeleteRefToEntityUniqueConstraintsRelatedForeignKey(EntityUniqueConstraintsRelatedForeignKey relatedEntityUniqueConstraintsRelatedForeignKey)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToEntityUniqueConstraintsRelatedForeignKey()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}