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

public partial class TestEntityZeroOrMany : TestEntityZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for TestEntityZeroOrMany created event.
/// </summary>
public record TestEntityZeroOrManyCreated(TestEntityZeroOrMany TestEntityZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrMany updated event.
/// </summary>
public record TestEntityZeroOrManyUpdated(TestEntityZeroOrMany TestEntityZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityZeroOrMany deleted event.
/// </summary>
public record TestEntityZeroOrManyDeleted(TestEntityZeroOrMany TestEntityZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract partial class TestEntityZeroOrManyBase : AuditableEntityBase, IEtag
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

	protected virtual void InternalRaiseCreateEvent(TestEntityZeroOrMany testEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyCreated(testEntityZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityZeroOrMany testEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyUpdated(testEntityZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityZeroOrMany testEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new TestEntityZeroOrManyDeleted(testEntityZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// TestEntityZeroOrMany Test entity relationship to SecondTestEntityZeroOrMany ZeroOrMany SecondTestEntityZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManies { get; private set; } = new();

    public virtual void CreateRefToSecondTestEntityZeroOrManies(SecondTestEntityZeroOrMany relatedSecondTestEntityZeroOrMany)
    {
        SecondTestEntityZeroOrManies.Add(relatedSecondTestEntityZeroOrMany);
    }

    public virtual void UpdateRefToSecondTestEntityZeroOrManies(List<SecondTestEntityZeroOrMany> relatedSecondTestEntityZeroOrMany)
    {
        SecondTestEntityZeroOrManies.Clear();
        SecondTestEntityZeroOrManies.AddRange(relatedSecondTestEntityZeroOrMany);
    }

    public virtual void DeleteRefToSecondTestEntityZeroOrManies(SecondTestEntityZeroOrMany relatedSecondTestEntityZeroOrMany)
    {
        SecondTestEntityZeroOrManies.Remove(relatedSecondTestEntityZeroOrMany);
    }

    public virtual void DeleteAllRefToSecondTestEntityZeroOrManies()
    {
        SecondTestEntityZeroOrManies.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}