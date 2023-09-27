// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class CountryQualityOfLifeIndex:CountryQualityOfLifeIndexBase
{

}
/// <summary>
/// Record for CountryQualityOfLifeIndex created event.
/// </summary>
internal record CountryQualityOfLifeIndexCreated(CountryQualityOfLifeIndexBase CountryQualityOfLifeIndex) : IDomainEvent;
/// <summary>
/// Record for CountryQualityOfLifeIndex updated event.
/// </summary>
internal record CountryQualityOfLifeIndexUpdated(CountryQualityOfLifeIndexBase CountryQualityOfLifeIndex) : IDomainEvent;
/// <summary>
/// Record for CountryQualityOfLifeIndex deleted event.
/// </summary>
internal record CountryQualityOfLifeIndexDeleted(CountryQualityOfLifeIndexBase CountryQualityOfLifeIndex) : IDomainEvent;

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
internal abstract class CountryQualityOfLifeIndexBase : EntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	protected readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CountryQualityOfLifeIndexCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new CountryQualityOfLifeIndexUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new CountryQualityOfLifeIndexDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}