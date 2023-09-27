// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class RatingProgram:RatingProgramBase
{

}
/// <summary>
/// Record for RatingProgram created event.
/// </summary>
internal record RatingProgramCreated(RatingProgramBase RatingProgram) : IDomainEvent;
/// <summary>
/// Record for RatingProgram updated event.
/// </summary>
internal record RatingProgramUpdated(RatingProgramBase RatingProgram) : IDomainEvent;
/// <summary>
/// Record for RatingProgram deleted event.
/// </summary>
internal record RatingProgramDeleted(RatingProgramBase RatingProgram) : IDomainEvent;

/// <summary>
/// Rating program for store.
/// </summary>
internal abstract class RatingProgramBase : EntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Guid StoreId { get; set; } = null!;
    
        public virtual Store Store { get; set; } = null!;
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public Nox.Types.Text? Name { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	protected readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new RatingProgramCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new RatingProgramUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new RatingProgramDeleted(this));
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