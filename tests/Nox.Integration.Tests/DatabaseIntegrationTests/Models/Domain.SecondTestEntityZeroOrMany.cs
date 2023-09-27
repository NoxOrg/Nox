// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityZeroOrMany:SecondTestEntityZeroOrManyBase
{

}
/// <summary>
/// Record for SecondTestEntityZeroOrMany created event.
/// </summary>
public record SecondTestEntityZeroOrManyCreated(SecondTestEntityZeroOrManyBase SecondTestEntityZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityZeroOrMany updated event.
/// </summary>
public record SecondTestEntityZeroOrManyUpdated(SecondTestEntityZeroOrManyBase SecondTestEntityZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityZeroOrMany deleted event.
/// </summary>
public record SecondTestEntityZeroOrManyDeleted(SecondTestEntityZeroOrManyBase SecondTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityZeroOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityZeroOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityZeroOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityZeroOrMany Test entity relationship to TestEntityZeroOrMany ZeroOrMany TestEntityZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrMany> TestEntityZeroOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrManyRelationship(TestEntityZeroOrMany relatedTestEntityZeroOrMany)
    {
        TestEntityZeroOrManyRelationship.Add(relatedTestEntityZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrManyRelationship(TestEntityZeroOrMany relatedTestEntityZeroOrMany)
    {
        TestEntityZeroOrManyRelationship.Remove(relatedTestEntityZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyRelationship()
    {
        TestEntityZeroOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}