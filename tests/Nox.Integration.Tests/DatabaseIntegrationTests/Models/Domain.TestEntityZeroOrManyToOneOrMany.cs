// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToOneOrMany:TestEntityZeroOrManyToOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany created event.
/// </summary>
public record TestEntityZeroOrManyToOneOrManyCreated(TestEntityZeroOrManyToOneOrManyBase TestEntityZeroOrManyToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany updated event.
/// </summary>
public record TestEntityZeroOrManyToOneOrManyUpdated(TestEntityZeroOrManyToOneOrManyBase TestEntityZeroOrManyToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany deleted event.
/// </summary>
public record TestEntityZeroOrManyToOneOrManyDeleted(TestEntityZeroOrManyToOneOrManyBase TestEntityZeroOrManyToOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToOneOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityZeroOrManyToOneOrManyCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyToOneOrManyUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyToOneOrManyDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrManyToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrMany ZeroOrMany TestEntityOneOrManyToZeroOrManies
    /// </summary>
    public virtual List<TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrMany relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrMany.Add(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrMany relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrMany.Remove(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToZeroOrMany()
    {
        TestEntityOneOrManyToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}