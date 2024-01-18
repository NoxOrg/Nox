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

public partial class TestEntityForUniqueConstraints : TestEntityForUniqueConstraintsBase, IEntityHaveDomainEvents
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
/// Record for TestEntityForUniqueConstraints created event.
/// </summary>
public record TestEntityForUniqueConstraintsCreated(TestEntityForUniqueConstraints TestEntityForUniqueConstraints) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForUniqueConstraints updated event.
/// </summary>
public record TestEntityForUniqueConstraintsUpdated(TestEntityForUniqueConstraints TestEntityForUniqueConstraints) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForUniqueConstraints deleted event.
/// </summary>
public record TestEntityForUniqueConstraintsDeleted(TestEntityForUniqueConstraints TestEntityForUniqueConstraints) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract partial class TestEntityForUniqueConstraintsBase : EntityBase, IEtag
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
    public Nox.Types.Text TextField { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number NumberField { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number UniqueNumberField { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.CountryCode2 UniqueCountryCode { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.CurrencyCode3 UniqueCurrencyCode { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityForUniqueConstraints testEntityForUniqueConstraints)
	{
		InternalDomainEvents.Add(new TestEntityForUniqueConstraintsCreated(testEntityForUniqueConstraints));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityForUniqueConstraints testEntityForUniqueConstraints)
	{
		InternalDomainEvents.Add(new TestEntityForUniqueConstraintsUpdated(testEntityForUniqueConstraints));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityForUniqueConstraints testEntityForUniqueConstraints)
	{
		InternalDomainEvents.Add(new TestEntityForUniqueConstraintsDeleted(testEntityForUniqueConstraints));
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