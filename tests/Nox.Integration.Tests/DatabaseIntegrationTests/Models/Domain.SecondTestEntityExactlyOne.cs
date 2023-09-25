// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityExactlyOne:SecondTestEntityExactlyOneBase
{

}
/// <summary>
/// Record for SecondTestEntityExactlyOne created event.
/// </summary>
public record SecondTestEntityExactlyOneCreated(SecondTestEntityExactlyOneBase SecondTestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityExactlyOne updated event.
/// </summary>
public record SecondTestEntityExactlyOneUpdated(SecondTestEntityExactlyOneBase SecondTestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityExactlyOne deleted event.
/// </summary>
public record SecondTestEntityExactlyOneDeleted(SecondTestEntityExactlyOneBase SecondTestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityExactlyOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityExactlyOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityExactlyOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    public virtual TestEntityExactlyOne TestEntityExactlyOneRelationship { get; private set; } = null!;

    public virtual void CreateRefToTestEntityExactlyOneRelationship(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        TestEntityExactlyOneRelationship = relatedTestEntityExactlyOne;
    }

    public virtual void DeleteRefToTestEntityExactlyOneRelationship(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneRelationship()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}