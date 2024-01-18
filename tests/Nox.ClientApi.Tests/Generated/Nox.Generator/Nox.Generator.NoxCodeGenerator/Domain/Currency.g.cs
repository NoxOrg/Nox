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

namespace ClientApi.Domain;

public partial class Currency : CurrencyBase, IEntityHaveDomainEvents
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
/// Record for Currency created event.
/// </summary>
public record CurrencyCreated(Currency Currency) :  IDomainEvent, INotification;
/// <summary>
/// Record for Currency updated event.
/// </summary>
public record CurrencyUpdated(Currency Currency) : IDomainEvent, INotification;
/// <summary>
/// Record for Currency deleted event.
/// </summary>
public record CurrencyDeleted(Currency Currency) : IDomainEvent, INotification;

/// <summary>
/// Currency and related data.
/// </summary>
public abstract partial class CurrencyBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// Currency unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.CurrencyCode3 Id { get;  set; } = null!;

    /// <summary>
    /// Currency's name    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Name { get;  set; } = null!;

    /// <summary>
    /// Currency's symbol    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Symbol { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Currency currency)
	{
		InternalDomainEvents.Add(new CurrencyCreated(currency));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Currency currency)
	{
		InternalDomainEvents.Add(new CurrencyUpdated(currency));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Currency currency)
	{
		InternalDomainEvents.Add(new CurrencyDeleted(currency));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Currency List of store licenses where this currency is a default one OneOrMany StoreLicenses
    /// </summary>
    public virtual List<StoreLicense> StoreLicenseDefault { get; private set; } = new();

    public virtual void CreateRefToStoreLicenseDefault(StoreLicense relatedStoreLicense)
    {
        StoreLicenseDefault.Add(relatedStoreLicense);
    }

    public virtual void UpdateRefToStoreLicenseDefault(List<StoreLicense> relatedStoreLicense)
    {
        if(!relatedStoreLicense.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        StoreLicenseDefault.Clear();
        StoreLicenseDefault.AddRange(relatedStoreLicense);
    }

    public virtual void DeleteRefToStoreLicenseDefault(StoreLicense relatedStoreLicense)
    {
        if(StoreLicenseDefault.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        StoreLicenseDefault.Remove(relatedStoreLicense);
    }

    public virtual void DeleteAllRefToStoreLicenseDefault()
    {
        if(StoreLicenseDefault.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        StoreLicenseDefault.Clear();
    }

    /// <summary>
    /// Currency List of store licenses that were sold in this currency OneOrMany StoreLicenses
    /// </summary>
    public virtual List<StoreLicense> StoreLicenseSoldIn { get; private set; } = new();

    public virtual void CreateRefToStoreLicenseSoldIn(StoreLicense relatedStoreLicense)
    {
        StoreLicenseSoldIn.Add(relatedStoreLicense);
    }

    public virtual void UpdateRefToStoreLicenseSoldIn(List<StoreLicense> relatedStoreLicense)
    {
        if(!relatedStoreLicense.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        StoreLicenseSoldIn.Clear();
        StoreLicenseSoldIn.AddRange(relatedStoreLicense);
    }

    public virtual void DeleteRefToStoreLicenseSoldIn(StoreLicense relatedStoreLicense)
    {
        if(StoreLicenseSoldIn.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        StoreLicenseSoldIn.Remove(relatedStoreLicense);
    }

    public virtual void DeleteAllRefToStoreLicenseSoldIn()
    {
        if(StoreLicenseSoldIn.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        StoreLicenseSoldIn.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}