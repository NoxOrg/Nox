// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityForUniqueConstraints:TestEntityForUniqueConstraintsBase
{

}
/// <summary>
/// Record for TestEntityForUniqueConstraints created event.
/// </summary>
public record TestEntityForUniqueConstraintsCreated(TestEntityForUniqueConstraintsBase TestEntityForUniqueConstraints) : IDomainEvent;
/// <summary>
/// Record for TestEntityForUniqueConstraints updated event.
/// </summary>
public record TestEntityForUniqueConstraintsUpdated(TestEntityForUniqueConstraintsBase TestEntityForUniqueConstraints) : IDomainEvent;
/// <summary>
/// Record for TestEntityForUniqueConstraints deleted event.
/// </summary>
public record TestEntityForUniqueConstraintsDeleted(TestEntityForUniqueConstraintsBase TestEntityForUniqueConstraints) : IDomainEvent;

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class TestEntityForUniqueConstraintsBase : EntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Number NumberField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Number UniqueNumberField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.CountryCode2 UniqueCountryCode { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.CurrencyCode3 UniqueCurrencyCode { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new TestEntityForUniqueConstraintsCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityForUniqueConstraintsUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityForUniqueConstraintsDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}