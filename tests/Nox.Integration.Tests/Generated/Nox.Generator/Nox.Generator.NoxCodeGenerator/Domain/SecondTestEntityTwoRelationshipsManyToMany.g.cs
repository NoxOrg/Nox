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

internal partial class SecondTestEntityTwoRelationshipsManyToMany : SecondTestEntityTwoRelationshipsManyToManyBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityTwoRelationshipsManyToMany created event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsManyToManyCreated(SecondTestEntityTwoRelationshipsManyToMany SecondTestEntityTwoRelationshipsManyToMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsManyToManyUpdated(SecondTestEntityTwoRelationshipsManyToMany SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsManyToManyDeleted(SecondTestEntityTwoRelationshipsManyToMany SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityTwoRelationshipsManyToManyBase : EntityBase, IEntityConcurrent
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
    public Nox.Types.Text TextTestField2 { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityTwoRelationshipsManyToMany secondTestEntityTwoRelationshipsManyToMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsManyToManyCreated(secondTestEntityTwoRelationshipsManyToMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityTwoRelationshipsManyToMany secondTestEntityTwoRelationshipsManyToMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsManyToManyUpdated(secondTestEntityTwoRelationshipsManyToMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityTwoRelationshipsManyToMany secondTestEntityTwoRelationshipsManyToMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsManyToManyDeleted(secondTestEntityTwoRelationshipsManyToMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany First relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<TestEntityTwoRelationshipsManyToMany> TestRelationshipOneOnOtherSide { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Add(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void UpdateRefToTestRelationshipOneOnOtherSide(List<TestEntityTwoRelationshipsManyToMany> relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Clear();
        TestRelationshipOneOnOtherSide.AddRange(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Remove(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOneOnOtherSide()
    {
        TestRelationshipOneOnOtherSide.Clear();
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany Second relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<TestEntityTwoRelationshipsManyToMany> TestRelationshipTwoOnOtherSide { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Add(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void UpdateRefToTestRelationshipTwoOnOtherSide(List<TestEntityTwoRelationshipsManyToMany> relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Clear();
        TestRelationshipTwoOnOtherSide.AddRange(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Remove(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwoOnOtherSide()
    {
        TestRelationshipTwoOnOtherSide.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}