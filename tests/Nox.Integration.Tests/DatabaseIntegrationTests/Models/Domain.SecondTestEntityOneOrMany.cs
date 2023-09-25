// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOneOrMany:SecondTestEntityOneOrManyBase
{

}
/// <summary>
/// Record for SecondTestEntityOneOrMany created event.
/// </summary>
public record SecondTestEntityOneOrManyCreated(SecondTestEntityOneOrManyBase SecondTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOneOrMany updated event.
/// </summary>
public record SecondTestEntityOneOrManyUpdated(SecondTestEntityOneOrManyBase SecondTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOneOrMany deleted event.
/// </summary>
public record SecondTestEntityOneOrManyDeleted(SecondTestEntityOneOrManyBase SecondTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityOneOrManyCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityOneOrManyUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityOneOrManyDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityOneOrMany Test entity relationship to TestEntityOneOrMany OneOrMany TestEntityOneOrManies
    /// </summary>
    public virtual List<TestEntityOneOrMany> TestEntityOneOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToTestEntityOneOrManyRelationship(TestEntityOneOrMany relatedTestEntityOneOrMany)
    {
        TestEntityOneOrManyRelationship.Add(relatedTestEntityOneOrMany);
    }

    public virtual void DeleteRefToTestEntityOneOrManyRelationship(TestEntityOneOrMany relatedTestEntityOneOrMany)
    {
        if(TestEntityOneOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityOneOrManyRelationship.Remove(relatedTestEntityOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyRelationship()
    {
        if(TestEntityOneOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityOneOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}