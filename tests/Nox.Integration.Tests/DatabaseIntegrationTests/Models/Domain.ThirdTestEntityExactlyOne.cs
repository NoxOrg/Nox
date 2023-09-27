// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class ThirdTestEntityExactlyOne:ThirdTestEntityExactlyOneBase
{

}
/// <summary>
/// Record for ThirdTestEntityExactlyOne created event.
/// </summary>
public record ThirdTestEntityExactlyOneCreated(ThirdTestEntityExactlyOneBase ThirdTestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityExactlyOne updated event.
/// </summary>
public record ThirdTestEntityExactlyOneUpdated(ThirdTestEntityExactlyOneBase ThirdTestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityExactlyOne deleted event.
/// </summary>
public record ThirdTestEntityExactlyOneDeleted(ThirdTestEntityExactlyOneBase ThirdTestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class ThirdTestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new ThirdTestEntityExactlyOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new ThirdTestEntityExactlyOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new ThirdTestEntityExactlyOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// ThirdTestEntityExactlyOne Test entity relationship to ThirdTestEntityZeroOrOne ExactlyOne ThirdTestEntityZeroOrOnes
    /// </summary>
    public virtual ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOneRelationship { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity ThirdTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text ThirdTestEntityZeroOrOneRelationshipId { get; set; } = null!;

    public virtual void CreateRefToThirdTestEntityZeroOrOneRelationship(ThirdTestEntityZeroOrOne relatedThirdTestEntityZeroOrOne)
    {
        ThirdTestEntityZeroOrOneRelationship = relatedThirdTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToThirdTestEntityZeroOrOneRelationship(ThirdTestEntityZeroOrOne relatedThirdTestEntityZeroOrOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToThirdTestEntityZeroOrOneRelationship()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}