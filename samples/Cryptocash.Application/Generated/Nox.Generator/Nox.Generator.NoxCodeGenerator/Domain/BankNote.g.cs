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

namespace Cryptocash.Domain;

internal partial class BankNote : BankNoteBase, IEntityHaveDomainEvents
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
/// Record for BankNote created event.
/// </summary>
internal record BankNoteCreated(BankNote BankNote) :  IDomainEvent, INotification;
/// <summary>
/// Record for BankNote updated event.
/// </summary>
internal record BankNoteUpdated(BankNote BankNote) : IDomainEvent, INotification;
/// <summary>
/// Record for BankNote deleted event.
/// </summary>
internal record BankNoteDeleted(BankNote BankNote) : IDomainEvent, INotification;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
internal abstract partial class BankNoteBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Currency bank note unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// Currency's cash bank note identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text CashNote { get;  set; } = null!;

    /// <summary>
    /// Bank note value    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Money Value { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(BankNote bankNote)
	{
		InternalDomainEvents.Add(new BankNoteCreated(bankNote));
    }
	
	protected virtual void InternalRaiseUpdateEvent(BankNote bankNote)
	{
		InternalDomainEvents.Add(new BankNoteUpdated(bankNote));
    }
	
	protected virtual void InternalRaiseDeleteEvent(BankNote bankNote)
	{
		InternalDomainEvents.Add(new BankNoteDeleted(bankNote));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}