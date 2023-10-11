// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

internal partial class CountryQualityOfLifeIndex : CountryQualityOfLifeIndexBase, IEntityHaveDomainEvents
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
/// Record for CountryQualityOfLifeIndex created event.
/// </summary>
internal record CountryQualityOfLifeIndexCreated(CountryQualityOfLifeIndex CountryQualityOfLifeIndex) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryQualityOfLifeIndex updated event.
/// </summary>
internal record CountryQualityOfLifeIndexUpdated(CountryQualityOfLifeIndex CountryQualityOfLifeIndex) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryQualityOfLifeIndex deleted event.
/// </summary>
internal record CountryQualityOfLifeIndexDeleted(CountryQualityOfLifeIndex CountryQualityOfLifeIndex) : IDomainEvent, INotification;

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
internal abstract partial class CountryQualityOfLifeIndexBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber CountryId { get; set; } = null!;
    
        public virtual Country Country { get; set; } = null!;
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Rating Index (Required).
    /// </summary>
    public Nox.Types.Number IndexRating { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

    protected virtual void InternalRaiseCreateEvent(CountryQualityOfLifeIndex countryQualityOfLifeIndex)
    {
        InternalDomainEvents.Add(new CountryQualityOfLifeIndexCreated(countryQualityOfLifeIndex));
    }
	
    protected virtual void InternalRaiseUpdateEvent(CountryQualityOfLifeIndex countryQualityOfLifeIndex)
    {
        InternalDomainEvents.Add(new CountryQualityOfLifeIndexUpdated(countryQualityOfLifeIndex));
    }
	
    protected virtual void InternalRaiseDeleteEvent(CountryQualityOfLifeIndex countryQualityOfLifeIndex)
    {
        InternalDomainEvents.Add(new CountryQualityOfLifeIndexDeleted(countryQualityOfLifeIndex));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}