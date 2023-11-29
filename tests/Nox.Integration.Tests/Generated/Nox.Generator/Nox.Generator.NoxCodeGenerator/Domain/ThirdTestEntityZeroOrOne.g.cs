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

namespace TestWebApp.Domain;

internal partial class ThirdTestEntityZeroOrOne : ThirdTestEntityZeroOrOneBase, IEntityHaveDomainEvents
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
/// Record for ThirdTestEntityZeroOrOne created event.
/// </summary>
internal record ThirdTestEntityZeroOrOneCreated(ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityZeroOrOne updated event.
/// </summary>
internal record ThirdTestEntityZeroOrOneUpdated(ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOne) : IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityZeroOrOne deleted event.
/// </summary>
internal record ThirdTestEntityZeroOrOneDeleted(ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class ThirdTestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(ThirdTestEntityZeroOrOne thirdTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new ThirdTestEntityZeroOrOneCreated(thirdTestEntityZeroOrOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(ThirdTestEntityZeroOrOne thirdTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new ThirdTestEntityZeroOrOneUpdated(thirdTestEntityZeroOrOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(ThirdTestEntityZeroOrOne thirdTestEntityZeroOrOne)
	{
		InternalDomainEvents.Add(new ThirdTestEntityZeroOrOneDeleted(thirdTestEntityZeroOrOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// ThirdTestEntityZeroOrOne Test entity relationship to ThirdTestEntityExactlyOne ZeroOrOne ThirdTestEntityExactlyOnes
    /// </summary>
    public virtual ThirdTestEntityExactlyOne? ThirdTestEntityExactlyOne { get; private set; } = null!;

    public virtual void CreateRefToThirdTestEntityExactlyOne(ThirdTestEntityExactlyOne relatedThirdTestEntityExactlyOne)
    {
        ThirdTestEntityExactlyOne = relatedThirdTestEntityExactlyOne;
    }

    public virtual void DeleteRefToThirdTestEntityExactlyOne(ThirdTestEntityExactlyOne relatedThirdTestEntityExactlyOne)
    {
        ThirdTestEntityExactlyOne = null;
    }

    public virtual void DeleteAllRefToThirdTestEntityExactlyOne()
    {
        ThirdTestEntityExactlyOne = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}