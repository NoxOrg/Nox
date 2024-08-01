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
using Nox.Exceptions;

namespace TestWebApp.Domain;

public partial class SecondTestEntityZeroOrOne : SecondTestEntityZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityZeroOrOne created event.
/// </summary>
public record SecondTestEntityZeroOrOneCreated(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityZeroOrOne updated event.
/// </summary>
public record SecondTestEntityZeroOrOneUpdated(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityZeroOrOne deleted event.
/// </summary>
public record SecondTestEntityZeroOrOneDeleted(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
public abstract partial class SecondTestEntityZeroOrOneBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityZeroOrOne secondTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrOneCreated(secondTestEntityZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityZeroOrOne secondTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrOneUpdated(secondTestEntityZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityZeroOrOne secondTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityZeroOrOneDeleted(secondTestEntityZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityZeroOrOne Test entity relationship to TestEntity ZeroOrOne TestEntityZeroOrOnes
    /// </summary>
    public virtual TestEntityZeroOrOne? TestEntityZeroOrOne { get; private set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOne(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOne = relatedTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrOne(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOne = null;
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOne()
    {
        TestEntityZeroOrOne = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}