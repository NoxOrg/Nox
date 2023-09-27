// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class ThirdTestEntityZeroOrMany:ThirdTestEntityZeroOrManyBase
{

}
/// <summary>
/// Record for ThirdTestEntityZeroOrMany created event.
/// </summary>
public record ThirdTestEntityZeroOrManyCreated(ThirdTestEntityZeroOrManyBase ThirdTestEntityZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityZeroOrMany updated event.
/// </summary>
public record ThirdTestEntityZeroOrManyUpdated(ThirdTestEntityZeroOrManyBase ThirdTestEntityZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityZeroOrMany deleted event.
/// </summary>
public record ThirdTestEntityZeroOrManyDeleted(ThirdTestEntityZeroOrManyBase ThirdTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new ThirdTestEntityZeroOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new ThirdTestEntityZeroOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new ThirdTestEntityZeroOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// ThirdTestEntityZeroOrMany Test entity relationship to ThirdTestEntityOneOrMany ZeroOrMany ThirdTestEntityOneOrManies
    /// </summary>
    public virtual List<ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToThirdTestEntityOneOrManyRelationship(ThirdTestEntityOneOrMany relatedThirdTestEntityOneOrMany)
    {
        ThirdTestEntityOneOrManyRelationship.Add(relatedThirdTestEntityOneOrMany);
    }

    public virtual void DeleteRefToThirdTestEntityOneOrManyRelationship(ThirdTestEntityOneOrMany relatedThirdTestEntityOneOrMany)
    {
        ThirdTestEntityOneOrManyRelationship.Remove(relatedThirdTestEntityOneOrMany);
    }

    public virtual void DeleteAllRefToThirdTestEntityOneOrManyRelationship()
    {
        ThirdTestEntityOneOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}