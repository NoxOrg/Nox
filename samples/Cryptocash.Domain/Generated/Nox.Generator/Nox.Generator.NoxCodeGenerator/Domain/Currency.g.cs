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
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Currency's iso number id    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.CurrencyNumber CurrencyIsoNumeric { get;  set; } = null!;

    /// <summary>
    /// Currency's symbol    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Symbol { get;  set; } = null!;

    /// <summary>
    /// Currency's numeric thousands notation separator    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? ThousandsSeparator { get;  set; } = null!;

    /// <summary>
    /// Currency's numeric decimal notation separator    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? DecimalSeparator { get;  set; } = null!;

    /// <summary>
    /// Currency's numeric space between amount and symbol    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Boolean SpaceBetweenAmountAndSymbol { get;  set; } = null!;

    /// <summary>
    /// Currency's symbol position    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Boolean SymbolOnLeft { get;  set; } = null!;

    /// <summary>
    /// Currency's numeric decimal digits    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number DecimalDigits { get;  set; } = null!;

    /// <summary>
    /// Currency's major name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text MajorName { get;  set; } = null!;

    /// <summary>
    /// Currency's major display symbol    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text MajorSymbol { get;  set; } = null!;

    /// <summary>
    /// Currency's minor name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text MinorName { get;  set; } = null!;

    /// <summary>
    /// Currency's minor display symbol    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text MinorSymbol { get;  set; } = null!;

    /// <summary>
    /// Currency's minor value when converted to major    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Money MinorToMajorValue { get;  set; } = null!;
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
    /// Currency used by OneOrMany Countries
    /// </summary>
    public virtual List<Country> Countries { get; private set; } = new();

    public virtual void CreateRefToCountries(Country relatedCountry)
    {
        Countries.Add(relatedCountry);
    }

    public virtual void UpdateRefToCountries(List<Country> relatedCountry)
    {
        if(!relatedCountry.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        Countries.Clear();
        Countries.AddRange(relatedCountry);
    }

    public virtual void DeleteRefToCountries(Country relatedCountry)
    {
        if(Countries.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        Countries.Remove(relatedCountry);
    }

    public virtual void DeleteAllRefToCountries()
    {
        if(Countries.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        Countries.Clear();
    }

    /// <summary>
    /// Currency used by ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> MinimumCashStocks { get; private set; } = new();

    public virtual void CreateRefToMinimumCashStocks(MinimumCashStock relatedMinimumCashStock)
    {
        MinimumCashStocks.Add(relatedMinimumCashStock);
    }

    public virtual void UpdateRefToMinimumCashStocks(List<MinimumCashStock> relatedMinimumCashStock)
    {
        MinimumCashStocks.Clear();
        MinimumCashStocks.AddRange(relatedMinimumCashStock);
    }

    public virtual void DeleteRefToMinimumCashStocks(MinimumCashStock relatedMinimumCashStock)
    {
        MinimumCashStocks.Remove(relatedMinimumCashStock);
    }

    public virtual void DeleteAllRefToMinimumCashStocks()
    {
        MinimumCashStocks.Clear();
    }﻿

    /// <summary>
    /// Currency commonly used ZeroOrMany BankNotes
    /// </summary>
    public virtual List<BankNote> BankNotes { get; private set; } = new();
    
    /// <summary>
    /// Creates a new BankNote entity.
    /// </summary>
    public virtual void CreateRefToBankNotes(BankNote relatedBankNote)
    {
        BankNotes.Add(relatedBankNote);
    }
    
    /// <summary>
    /// Updates all owned BankNote entities.
    /// </summary>
    public virtual void UpdateRefToBankNotes(List<BankNote> relatedBankNote)
    {
        BankNotes.Clear();
        BankNotes.AddRange(relatedBankNote);
    }
    
    /// <summary>
    /// Deletes owned BankNote entity.
    /// </summary>
    public virtual void DeleteRefToBankNotes(BankNote relatedBankNote)
    {
        BankNotes.Remove(relatedBankNote);
    }
    
    /// <summary>
    /// Deletes all owned BankNote entities.
    /// </summary>
    public virtual void DeleteAllRefToBankNotes()
    {
        BankNotes.Clear();
    }﻿

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRate> ExchangeRates { get; private set; } = new();
    
    /// <summary>
    /// Creates a new ExchangeRate entity.
    /// </summary>
    public virtual void CreateRefToExchangeRates(ExchangeRate relatedExchangeRate)
    {
        ExchangeRates.Add(relatedExchangeRate);
    }
    
    /// <summary>
    /// Updates all owned ExchangeRate entities.
    /// </summary>
    public virtual void UpdateRefToExchangeRates(List<ExchangeRate> relatedExchangeRate)
    {
        if(!relatedExchangeRate.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        ExchangeRates.Clear();
        ExchangeRates.AddRange(relatedExchangeRate);
    }
    
    /// <summary>
    /// Deletes owned ExchangeRate entity.
    /// </summary>
    public virtual void DeleteRefToExchangeRates(ExchangeRate relatedExchangeRate)
    {
        if(ExchangeRates.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        ExchangeRates.Remove(relatedExchangeRate);
    }
    
    /// <summary>
    /// Deletes all owned ExchangeRate entities.
    /// </summary>
    public virtual void DeleteAllRefToExchangeRates()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}