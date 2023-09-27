// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipZeroOrOne:SecondTestEntityOwnedRelationshipZeroOrOneBase
{

}
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneCreated(SecondTestEntityOwnedRelationshipZeroOrOneBase SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneUpdated(SecondTestEntityOwnedRelationshipZeroOrOneBase SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneDeleted(SecondTestEntityOwnedRelationshipZeroOrOneBase SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipZeroOrOneBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}