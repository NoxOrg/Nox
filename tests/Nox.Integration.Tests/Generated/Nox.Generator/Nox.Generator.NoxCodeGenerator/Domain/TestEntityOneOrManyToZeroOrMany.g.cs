// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace TestWebApp.Domain;

public partial class TestEntityOneOrManyToZeroOrMany : TestEntityOneOrManyToZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityOneOrManyToZeroOrMany created event.
/// </summary>
public record TestEntityOneOrManyToZeroOrManyCreated(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany updated event.
/// </summary>
public record TestEntityOneOrManyToZeroOrManyUpdated(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany deleted event.
/// </summary>
public record TestEntityOneOrManyToZeroOrManyDeleted(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract partial class TestEntityOneOrManyToZeroOrManyBase : AuditableEntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityOneOrManyToZeroOrMany testEntityOneOrManyToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrManyCreated(testEntityOneOrManyToZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityOneOrManyToZeroOrMany testEntityOneOrManyToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrManyUpdated(testEntityOneOrManyToZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityOneOrManyToZeroOrMany testEntityOneOrManyToZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityOneOrManyToZeroOrManyDeleted(testEntityOneOrManyToZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityOneOrManyToZeroOrMany Test entity relationship to TestEntityZeroOrManyToOneOrMany OneOrMany TestEntityZeroOrManyToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrManies { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrManyToOneOrManies(TestEntityZeroOrManyToOneOrMany relatedTestEntityZeroOrManyToOneOrMany)
    {
        TestEntityZeroOrManyToOneOrManies.Add(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void UpdateRefToTestEntityZeroOrManyToOneOrManies(List<TestEntityZeroOrManyToOneOrMany> relatedTestEntityZeroOrManyToOneOrMany)
    {
        if(!relatedTestEntityZeroOrManyToOneOrMany.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        TestEntityZeroOrManyToOneOrManies.Clear();
        TestEntityZeroOrManyToOneOrManies.AddRange(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrManyToOneOrManies(TestEntityZeroOrManyToOneOrMany relatedTestEntityZeroOrManyToOneOrMany)
    {
        if(TestEntityZeroOrManyToOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityZeroOrManyToOneOrManies.Remove(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyToOneOrManies()
    {
        if(TestEntityZeroOrManyToOneOrManies.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        TestEntityZeroOrManyToOneOrManies.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}