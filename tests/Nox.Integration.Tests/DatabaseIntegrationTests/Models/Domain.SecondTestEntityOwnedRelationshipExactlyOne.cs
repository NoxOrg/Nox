// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipExactlyOne:SecondTestEntityOwnedRelationshipExactlyOneBase
{

}
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipExactlyOneCreated(SecondTestEntityOwnedRelationshipExactlyOneBase SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipExactlyOneUpdated(SecondTestEntityOwnedRelationshipExactlyOneBase SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipExactlyOneDeleted(SecondTestEntityOwnedRelationshipExactlyOneBase SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipExactlyOneBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id1 { get; set; } = null!;

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
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipExactlyOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipExactlyOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipExactlyOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}