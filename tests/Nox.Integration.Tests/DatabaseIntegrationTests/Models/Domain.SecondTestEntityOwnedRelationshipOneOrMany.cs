// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipOneOrMany:SecondTestEntityOwnedRelationshipOneOrManyBase
{

}
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipOneOrManyCreated(SecondTestEntityOwnedRelationshipOneOrManyBase SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipOneOrManyUpdated(SecondTestEntityOwnedRelationshipOneOrManyBase SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipOneOrManyDeleted(SecondTestEntityOwnedRelationshipOneOrManyBase SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipOneOrManyBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipOneOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipOneOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityOwnedRelationshipOneOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}