// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
public partial class EmailAddress:EmailAddressBase
{

}
/// <summary>
/// Record for EmailAddress created event.
/// </summary>
public record EmailAddressCreated(EmailAddressBase EmailAddress) : IDomainEvent;
/// <summary>
/// Record for EmailAddress updated event.
/// </summary>
public record EmailAddressUpdated(EmailAddressBase EmailAddress) : IDomainEvent;
/// <summary>
/// Record for EmailAddress deleted event.
/// </summary>
public record EmailAddressDeleted(EmailAddressBase EmailAddress) : IDomainEvent;

/// <summary>
/// Verified Email Address.
/// </summary>
public abstract class EmailAddressBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{

    /// <summary>
    /// Email (Optional).
    /// </summary>
    public Nox.Types.Email? Email { get; set; } = null!;

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public Nox.Types.Boolean? IsVerified { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new EmailAddressCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new EmailAddressUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new EmailAddressDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}