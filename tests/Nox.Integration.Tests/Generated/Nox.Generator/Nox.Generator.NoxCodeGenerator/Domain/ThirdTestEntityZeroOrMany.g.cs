// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

internal partial class ThirdTestEntityZeroOrMany : ThirdTestEntityZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for ThirdTestEntityZeroOrMany created event.
/// </summary>
internal record ThirdTestEntityZeroOrManyCreated(ThirdTestEntityZeroOrMany ThirdTestEntityZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityZeroOrMany updated event.
/// </summary>
internal record ThirdTestEntityZeroOrManyUpdated(ThirdTestEntityZeroOrMany ThirdTestEntityZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityZeroOrMany deleted event.
/// </summary>
internal record ThirdTestEntityZeroOrManyDeleted(ThirdTestEntityZeroOrMany ThirdTestEntityZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class ThirdTestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(ThirdTestEntityZeroOrMany thirdTestEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new ThirdTestEntityZeroOrManyCreated(thirdTestEntityZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(ThirdTestEntityZeroOrMany thirdTestEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new ThirdTestEntityZeroOrManyUpdated(thirdTestEntityZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(ThirdTestEntityZeroOrMany thirdTestEntityZeroOrMany)
	{
		InternalDomainEvents.Add(new ThirdTestEntityZeroOrManyDeleted(thirdTestEntityZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// ThirdTestEntityZeroOrMany Test entity relationship to ThirdTestEntityOneOrMany ZeroOrMany ThirdTestEntityOneOrManies
    /// </summary>
    public virtual List<ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToThirdTestEntityOneOrManyRelationship(ThirdTestEntityOneOrMany relatedThirdTestEntityOneOrMany)
    {
        ThirdTestEntityOneOrManyRelationship.Add(relatedThirdTestEntityOneOrMany);
    }

    public virtual void UpdateRefToThirdTestEntityOneOrManyRelationship(List<ThirdTestEntityOneOrMany> relatedThirdTestEntityOneOrMany)
    {
        ThirdTestEntityOneOrManyRelationship.Clear();
        ThirdTestEntityOneOrManyRelationship.AddRange(relatedThirdTestEntityOneOrMany);
    }

    public virtual void DeleteRefToThirdTestEntityOneOrManyRelationship(ThirdTestEntityOneOrMany relatedThirdTestEntityOneOrMany)
    {
        ThirdTestEntityOneOrManyRelationship.Remove(relatedThirdTestEntityOneOrMany);
    }

    public virtual void DeleteAllRefToThirdTestEntityOneOrManyRelationship()
    {
        ThirdTestEntityOneOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}