// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

internal partial class SecondTestEntityOneOrMany : SecondTestEntityOneOrManyBase, IEntityHaveDomainEvents
{
	///<inheritdoc/>
	public void RaiseCreateEvent()
	{
		InternalRaiseCreateEvent(this);
	}
	///<inheritdoc/>
	public void RaiseDeleteEvent()
	{
		InternalRaiseDeleteEvent(this);
	}
	///<inheritdoc/>
	public void RaiseUpdateEvent()
	{
		InternalRaiseUpdateEvent(this);
	}
}
/// <summary>
/// Record for SecondTestEntityOneOrMany created event.
/// </summary>
internal record SecondTestEntityOneOrManyCreated(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOneOrMany updated event.
/// </summary>
internal record SecondTestEntityOneOrManyUpdated(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOneOrMany deleted event.
/// </summary>
internal record SecondTestEntityOneOrManyDeleted(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityOneOrMany secondTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOneOrManyCreated(secondTestEntityOneOrMany));
	}
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityOneOrMany secondTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOneOrManyUpdated(secondTestEntityOneOrMany));
	}
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityOneOrMany secondTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityOneOrManyDeleted(secondTestEntityOneOrMany));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
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