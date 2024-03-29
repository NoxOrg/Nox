﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace TestWebApp.Domain;

public partial class SecondTestEntityExactlyOne : SecondTestEntityExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityExactlyOne created event.
/// </summary>
public record SecondTestEntityExactlyOneCreated(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityExactlyOne updated event.
/// </summary>
public record SecondTestEntityExactlyOneUpdated(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityExactlyOne deleted event.
/// </summary>
public record SecondTestEntityExactlyOneDeleted(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class SecondTestEntityExactlyOneBase : AuditableEntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField2 { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityExactlyOne secondTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityExactlyOneCreated(secondTestEntityExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityExactlyOne secondTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityExactlyOneUpdated(secondTestEntityExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityExactlyOne secondTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityExactlyOneDeleted(secondTestEntityExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    public virtual TestEntityExactlyOne TestEntityExactlyOne { get; private set; } = null!;

    public virtual void CreateRefToTestEntityExactlyOne(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        TestEntityExactlyOne = relatedTestEntityExactlyOne;
    }

    public virtual void DeleteRefToTestEntityExactlyOne(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityExactlyOne()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}