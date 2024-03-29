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

public partial class SecondTestEntityOneOrMany : SecondTestEntityOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityOneOrMany created event.
/// </summary>
public record SecondTestEntityOneOrManyCreated(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOneOrMany updated event.
/// </summary>
public record SecondTestEntityOneOrManyUpdated(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityOneOrMany deleted event.
/// </summary>
public record SecondTestEntityOneOrManyDeleted(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class SecondTestEntityOneOrManyBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityOneOrMany secondTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOneOrManyCreated(secondTestEntityOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityOneOrMany secondTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOneOrManyUpdated(secondTestEntityOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityOneOrMany secondTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOneOrManyDeleted(secondTestEntityOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityOneOrMany Test entity relationship to TestEntityOneOrMany OneOrMany TestEntityOneOrManies
    /// </summary>
    public virtual List<TestEntityOneOrMany> TestEntityOneOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityOneOrManies(TestEntityOneOrMany relatedTestEntityOneOrMany)
    {
        TestEntityOneOrManies.Add(relatedTestEntityOneOrMany);
    }

    public virtual void UpdateRefToTestEntityOneOrManies(List<TestEntityOneOrMany> relatedTestEntityOneOrMany)
    {
        if(!relatedTestEntityOneOrMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestEntityOneOrManies.Clear();
        TestEntityOneOrManies.AddRange(relatedTestEntityOneOrMany);
    }

    public virtual void DeleteRefToTestEntityOneOrManies(TestEntityOneOrMany relatedTestEntityOneOrMany)
    {
        if(TestEntityOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityOneOrManies.Remove(relatedTestEntityOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityOneOrManies()
    {
        if(TestEntityOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityOneOrManies.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}