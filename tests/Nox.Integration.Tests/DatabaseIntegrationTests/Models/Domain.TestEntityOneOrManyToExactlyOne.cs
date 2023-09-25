// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOneOrManyToExactlyOne:TestEntityOneOrManyToExactlyOneBase
{

}
/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne created event.
/// </summary>
public record TestEntityOneOrManyToExactlyOneCreated(TestEntityOneOrManyToExactlyOneBase TestEntityOneOrManyToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne updated event.
/// </summary>
public record TestEntityOneOrManyToExactlyOneUpdated(TestEntityOneOrManyToExactlyOneBase TestEntityOneOrManyToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne deleted event.
/// </summary>
public record TestEntityOneOrManyToExactlyOneDeleted(TestEntityOneOrManyToExactlyOneBase TestEntityOneOrManyToExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOneOrManyToExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityOneOrManyToExactlyOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityOneOrManyToExactlyOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityOneOrManyToExactlyOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOneOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToOneOrMany OneOrMany TestEntityExactlyOneToOneOrManies
    /// </summary>
    public virtual List<TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityExactlyOneToOneOrMany(TestEntityExactlyOneToOneOrMany relatedTestEntityExactlyOneToOneOrMany)
    {
        TestEntityExactlyOneToOneOrMany.Add(relatedTestEntityExactlyOneToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityExactlyOneToOneOrMany(TestEntityExactlyOneToOneOrMany relatedTestEntityExactlyOneToOneOrMany)
    {
        if(TestEntityExactlyOneToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityExactlyOneToOneOrMany.Remove(relatedTestEntityExactlyOneToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToOneOrMany()
    {
        if(TestEntityExactlyOneToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityExactlyOneToOneOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}