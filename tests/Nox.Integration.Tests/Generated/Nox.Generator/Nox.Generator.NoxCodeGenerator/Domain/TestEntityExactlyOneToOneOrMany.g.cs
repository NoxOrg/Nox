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

internal partial class TestEntityExactlyOneToOneOrMany : TestEntityExactlyOneToOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityExactlyOneToOneOrMany created event.
/// </summary>
internal record TestEntityExactlyOneToOneOrManyCreated(TestEntityExactlyOneToOneOrMany TestEntityExactlyOneToOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany updated event.
/// </summary>
internal record TestEntityExactlyOneToOneOrManyUpdated(TestEntityExactlyOneToOneOrMany TestEntityExactlyOneToOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany deleted event.
/// </summary>
internal record TestEntityExactlyOneToOneOrManyDeleted(TestEntityExactlyOneToOneOrMany TestEntityExactlyOneToOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityExactlyOneToOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(TestEntityExactlyOneToOneOrMany testEntityExactlyOneToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneToOneOrManyCreated(testEntityExactlyOneToOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityExactlyOneToOneOrMany testEntityExactlyOneToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneToOneOrManyUpdated(testEntityExactlyOneToOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityExactlyOneToOneOrMany testEntityExactlyOneToOneOrMany)
	{
		InternalDomainEvents.Add(new TestEntityExactlyOneToOneOrManyDeleted(testEntityExactlyOneToOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityExactlyOneToOneOrMany Test entity relationship to TestEntityOneOrManyToExactlyOne ExactlyOne TestEntityOneOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityOneOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityOneOrManyToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOne relatedTestEntityOneOrManyToExactlyOne)
    {
        TestEntityOneOrManyToExactlyOne = relatedTestEntityOneOrManyToExactlyOne;
    }

    public virtual void DeleteRefToTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOne relatedTestEntityOneOrManyToExactlyOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToExactlyOne()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}