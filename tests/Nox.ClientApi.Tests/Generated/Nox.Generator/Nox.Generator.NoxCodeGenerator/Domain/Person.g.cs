﻿// Generated

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

namespace ClientApi.Domain;

public partial class Person : PersonBase, IEntityHaveDomainEvents
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
/// Record for Person created event.
/// </summary>
public record PersonCreated(Person Person) :  IDomainEvent, INotification;
/// <summary>
/// Record for Person updated event.
/// </summary>
public record PersonUpdated(Person Person) : IDomainEvent, INotification;
/// <summary>
/// Record for Person deleted event.
/// </summary>
public record PersonDeleted(Person Person) : IDomainEvent, INotification;

/// <summary>
/// Person.
/// </summary>
public abstract partial class PersonBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// The person unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// The user's first name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text FirstName { get;  set; } = null!;

    /// <summary>
    /// The customer's last name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text LastName { get;  set; } = null!;

    /// <summary>
    /// Tenant user bellongs to    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid TenantId { get;  set; } = null!;

    /// <summary>
    /// The user's primary email for MFA    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Email PrimaryEmailAddress { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Person person)
	{
		InternalDomainEvents.Add(new PersonCreated(person));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Person person)
	{
		InternalDomainEvents.Add(new PersonUpdated(person));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Person person)
	{
		InternalDomainEvents.Add(new PersonDeleted(person));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }﻿

    /// <summary>
    /// Person user selected contacts ZeroOrOne UserContactSelections
    /// </summary>
    public virtual UserContactSelection? UserContactSelection { get; private set; }
    
    /// <summary>
    /// Creates a new UserContactSelection entity.
    /// </summary>
    public virtual void CreateUserContactSelection(UserContactSelection relatedUserContactSelection)
    {
        UserContactSelection = relatedUserContactSelection;
    }
    
    /// <summary>
    /// Deletes owned UserContactSelection entity.
    /// </summary>
    public virtual void DeleteUserContactSelection(UserContactSelection relatedUserContactSelection)
    {
        UserContactSelection = null;
    }
    
    /// <summary>
    /// Deletes all owned UserContactSelection entities.
    /// </summary>
    public virtual void DeleteAllUserContactSelection()
    {
        UserContactSelection = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}