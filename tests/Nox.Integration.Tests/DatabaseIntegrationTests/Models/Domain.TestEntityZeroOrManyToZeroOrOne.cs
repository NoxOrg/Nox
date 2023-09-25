// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToZeroOrOne:TestEntityZeroOrManyToZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne created event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneCreated(TestEntityZeroOrManyToZeroOrOneBase TestEntityZeroOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne updated event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneUpdated(TestEntityZeroOrManyToZeroOrOneBase TestEntityZeroOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne deleted event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneDeleted(TestEntityZeroOrManyToZeroOrOneBase TestEntityZeroOrManyToZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityZeroOrManyToZeroOrOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyToZeroOrOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyToZeroOrOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrMany relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrMany.Add(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrMany relatedTestEntityZeroOrOneToZeroOrMany)
    {
        TestEntityZeroOrOneToZeroOrMany.Remove(relatedTestEntityZeroOrOneToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToZeroOrMany()
    {
        TestEntityZeroOrOneToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}