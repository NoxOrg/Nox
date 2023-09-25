// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOneOrManyToZeroOrOne:TestEntityOneOrManyToZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne created event.
/// </summary>
public record TestEntityOneOrManyToZeroOrOneCreated(TestEntityOneOrManyToZeroOrOneBase TestEntityOneOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne updated event.
/// </summary>
public record TestEntityOneOrManyToZeroOrOneUpdated(TestEntityOneOrManyToZeroOrOneBase TestEntityOneOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne deleted event.
/// </summary>
public record TestEntityOneOrManyToZeroOrOneDeleted(TestEntityOneOrManyToZeroOrOneBase TestEntityOneOrManyToZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOneOrManyToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityOneOrManyToZeroOrOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityOneOrManyToZeroOrOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityOneOrManyToZeroOrOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOneOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToOneOrMany OneOrMany TestEntityZeroOrOneToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        TestEntityZeroOrOneToOneOrMany.Add(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        if(TestEntityZeroOrOneToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityZeroOrOneToOneOrMany.Remove(relatedTestEntityZeroOrOneToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToOneOrMany()
    {
        if(TestEntityZeroOrOneToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityZeroOrOneToOneOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}