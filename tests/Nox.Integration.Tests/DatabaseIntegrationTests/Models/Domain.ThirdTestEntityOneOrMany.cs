// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class ThirdTestEntityOneOrMany:ThirdTestEntityOneOrManyBase
{

}
/// <summary>
/// Record for ThirdTestEntityOneOrMany created event.
/// </summary>
public record ThirdTestEntityOneOrManyCreated(ThirdTestEntityOneOrManyBase ThirdTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityOneOrMany updated event.
/// </summary>
public record ThirdTestEntityOneOrManyUpdated(ThirdTestEntityOneOrManyBase ThirdTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityOneOrMany deleted event.
/// </summary>
public record ThirdTestEntityOneOrManyDeleted(ThirdTestEntityOneOrManyBase ThirdTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class ThirdTestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new ThirdTestEntityOneOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new ThirdTestEntityOneOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new ThirdTestEntityOneOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// ThirdTestEntityOneOrMany Test entity relationship to ThirdTestEntityZeroOrMany OneOrMany ThirdTestEntityZeroOrManies
    /// </summary>
    public virtual List<ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToThirdTestEntityZeroOrManyRelationship(ThirdTestEntityZeroOrMany relatedThirdTestEntityZeroOrMany)
    {
        ThirdTestEntityZeroOrManyRelationship.Add(relatedThirdTestEntityZeroOrMany);
    }

    public virtual void DeleteRefToThirdTestEntityZeroOrManyRelationship(ThirdTestEntityZeroOrMany relatedThirdTestEntityZeroOrMany)
    {
        if(ThirdTestEntityZeroOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        ThirdTestEntityZeroOrManyRelationship.Remove(relatedThirdTestEntityZeroOrMany);
    }

    public virtual void DeleteAllRefToThirdTestEntityZeroOrManyRelationship()
    {
        if(ThirdTestEntityZeroOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        ThirdTestEntityZeroOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}