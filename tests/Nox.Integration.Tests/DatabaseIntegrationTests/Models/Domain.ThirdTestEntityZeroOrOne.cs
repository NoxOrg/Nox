// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class ThirdTestEntityZeroOrOne:ThirdTestEntityZeroOrOneBase
{

}
/// <summary>
/// Record for ThirdTestEntityZeroOrOne created event.
/// </summary>
public record ThirdTestEntityZeroOrOneCreated(ThirdTestEntityZeroOrOneBase ThirdTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityZeroOrOne updated event.
/// </summary>
public record ThirdTestEntityZeroOrOneUpdated(ThirdTestEntityZeroOrOneBase ThirdTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityZeroOrOne deleted event.
/// </summary>
public record ThirdTestEntityZeroOrOneDeleted(ThirdTestEntityZeroOrOneBase ThirdTestEntityZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new ThirdTestEntityZeroOrOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new ThirdTestEntityZeroOrOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new ThirdTestEntityZeroOrOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// ThirdTestEntityZeroOrOne Test entity relationship to ThirdTestEntityExactlyOne ZeroOrOne ThirdTestEntityExactlyOnes
    /// </summary>
    public virtual ThirdTestEntityExactlyOne? ThirdTestEntityExactlyOneRelationship { get; private set; } = null!;

    public virtual void CreateRefToThirdTestEntityExactlyOneRelationship(ThirdTestEntityExactlyOne relatedThirdTestEntityExactlyOne)
    {
        ThirdTestEntityExactlyOneRelationship = relatedThirdTestEntityExactlyOne;
    }

    public virtual void DeleteRefToThirdTestEntityExactlyOneRelationship(ThirdTestEntityExactlyOne relatedThirdTestEntityExactlyOne)
    {
        ThirdTestEntityExactlyOneRelationship = null;
    }

    public virtual void DeleteAllRefToThirdTestEntityExactlyOneRelationship()
    {
        ThirdTestEntityExactlyOneRelationship = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}