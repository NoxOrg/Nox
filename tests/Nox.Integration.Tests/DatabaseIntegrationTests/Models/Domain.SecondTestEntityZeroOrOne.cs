// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityZeroOrOne:SecondTestEntityZeroOrOneBase
{

}
/// <summary>
/// Record for SecondTestEntityZeroOrOne created event.
/// </summary>
public record SecondTestEntityZeroOrOneCreated(SecondTestEntityZeroOrOneBase SecondTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityZeroOrOne updated event.
/// </summary>
public record SecondTestEntityZeroOrOneUpdated(SecondTestEntityZeroOrOneBase SecondTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityZeroOrOne deleted event.
/// </summary>
public record SecondTestEntityZeroOrOneDeleted(SecondTestEntityZeroOrOneBase SecondTestEntityZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityZeroOrOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityZeroOrOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityZeroOrOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityZeroOrOne Test entity relationship to TestEntity ZeroOrOne TestEntityZeroOrOnes
    /// </summary>
    public virtual TestEntityZeroOrOne? TestEntityZeroOrOneRelationship { get; private set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOneRelationship(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOneRelationship = relatedTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrOneRelationship(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOneRelationship = null;
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneRelationship()
    {
        TestEntityZeroOrOneRelationship = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}