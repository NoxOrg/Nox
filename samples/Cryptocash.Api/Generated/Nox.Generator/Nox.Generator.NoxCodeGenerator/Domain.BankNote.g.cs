// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class BankNote:BankNoteBase
{

}
/// <summary>
/// Record for BankNote created event.
/// </summary>
public record BankNoteCreated(BankNoteBase BankNote) : IDomainEvent;
/// <summary>
/// Record for BankNote updated event.
/// </summary>
public record BankNoteUpdated(BankNoteBase BankNote) : IDomainEvent;
/// <summary>
/// Record for BankNote deleted event.
/// </summary>
public record BankNoteDeleted(BankNoteBase BankNote) : IDomainEvent;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public abstract class BankNoteBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    public Nox.Types.Text CashNote { get; set; } = null!;

    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    public Nox.Types.Money Value { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new BankNoteCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new BankNoteUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new BankNoteDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}