// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipZeroOrMany:SecondTestEntityOwnedRelationshipZeroOrManyBase
{

}
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrManyCreated(SecondTestEntityOwnedRelationshipZeroOrManyBase SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrManyUpdated(SecondTestEntityOwnedRelationshipZeroOrManyBase SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrManyDeleted(SecondTestEntityOwnedRelationshipZeroOrManyBase SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipZeroOrManyBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

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
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipZeroOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}