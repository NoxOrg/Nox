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

public partial class TestEntityForAutoNumberUsages : TestEntityForAutoNumberUsagesBase, IEntityHaveDomainEvents
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
/// Record for TestEntityForAutoNumberUsages created event.
/// </summary>
public record TestEntityForAutoNumberUsagesCreated(TestEntityForAutoNumberUsages TestEntityForAutoNumberUsages) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForAutoNumberUsages updated event.
/// </summary>
public record TestEntityForAutoNumberUsagesUpdated(TestEntityForAutoNumberUsages TestEntityForAutoNumberUsages) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForAutoNumberUsages deleted event.
/// </summary>
public record TestEntityForAutoNumberUsagesDeleted(TestEntityForAutoNumberUsages TestEntityForAutoNumberUsages) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public abstract partial class TestEntityForAutoNumberUsagesBase : EntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber AutoNumberFieldWithOptions { get; private set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber AutoNumberFieldWithoutOptions { get; private set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextField { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityForAutoNumberUsages testEntityForAutoNumberUsages)
	{
		InternalDomainEvents.Add(new TestEntityForAutoNumberUsagesCreated(testEntityForAutoNumberUsages));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityForAutoNumberUsages testEntityForAutoNumberUsages)
	{
		InternalDomainEvents.Add(new TestEntityForAutoNumberUsagesUpdated(testEntityForAutoNumberUsages));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityForAutoNumberUsages testEntityForAutoNumberUsages)
	{
		InternalDomainEvents.Add(new TestEntityForAutoNumberUsagesDeleted(testEntityForAutoNumberUsages));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}