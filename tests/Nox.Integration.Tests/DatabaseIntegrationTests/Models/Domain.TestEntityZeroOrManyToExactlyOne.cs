// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToExactlyOne:TestEntityZeroOrManyToExactlyOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne created event.
/// </summary>
public record TestEntityZeroOrManyToExactlyOneCreated(TestEntityZeroOrManyToExactlyOneBase TestEntityZeroOrManyToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne updated event.
/// </summary>
public record TestEntityZeroOrManyToExactlyOneUpdated(TestEntityZeroOrManyToExactlyOneBase TestEntityZeroOrManyToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne deleted event.
/// </summary>
public record TestEntityZeroOrManyToExactlyOneDeleted(TestEntityZeroOrManyToExactlyOneBase TestEntityZeroOrManyToExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityZeroOrManyToExactlyOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyToExactlyOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyToExactlyOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrMany ZeroOrMany TestEntityExactlyOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrMany relatedTestEntityExactlyOneToZeroOrMany)
    {
        TestEntityExactlyOneToZeroOrMany.Add(relatedTestEntityExactlyOneToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrMany relatedTestEntityExactlyOneToZeroOrMany)
    {
        TestEntityExactlyOneToZeroOrMany.Remove(relatedTestEntityExactlyOneToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToZeroOrMany()
    {
        TestEntityExactlyOneToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}