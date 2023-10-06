﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class Currency : CurrencyBase, IEntityHaveDomainEvents
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
internal record CurrencyCreated(Currency Currency) :  IDomainEvent, INotification;
/// <summary>
/// Record for Currency updated event.
/// </summary>
internal record CurrencyUpdated(Currency Currency) : IDomainEvent, INotification;
/// <summary>
/// Record for Currency deleted event.
/// </summary>
internal record CurrencyDeleted(Currency Currency) : IDomainEvent, INotification;

/// <summary>
/// Currency and related data.
/// </summary>
internal abstract partial class CurrencyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    public Nox.Types.CurrencyCode3 Id { get; set; } = null!;

    /// <summary>
    /// Currency's name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Currency's iso number id (Required).
    /// </summary>
    public Nox.Types.CurrencyNumber CurrencyIsoNumeric { get; set; } = null!;

    /// <summary>
    /// Currency's symbol (Required).
    /// </summary>
    public Nox.Types.Text Symbol { get; set; } = null!;

    /// <summary>
    /// Currency's numeric thousands notation separator (Optional).
    /// </summary>
    public Nox.Types.Text? ThousandsSeparator { get; set; } = null!;

    /// <summary>
    /// Currency's numeric decimal notation separator (Optional).
    /// </summary>
    public Nox.Types.Text? DecimalSeparator { get; set; } = null!;

    /// <summary>
    /// Currency's numeric space between amount and symbol (Required).
    /// </summary>
    public Nox.Types.Boolean SpaceBetweenAmountAndSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's numeric decimal digits (Required).
    /// </summary>
    public Nox.Types.Number DecimalDigits { get; set; } = null!;

    /// <summary>
    /// Currency's major name (Required).
    /// </summary>
    public Nox.Types.Text MajorName { get; set; } = null!;

    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    public Nox.Types.Text MajorSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    public Nox.Types.Text MinorName { get; set; } = null!;

    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    public Nox.Types.Text MinorSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    public Nox.Types.Money MinorToMajorValue { get; set; } = null!;
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
    public virtual List<Country> CurrencyUsedByCountry { get; private set; } = new();

    public virtual void CreateRefToCurrencyUsedByCountry(Country relatedCountry)
    {
        CurrencyUsedByCountry.Add(relatedCountry);
    }

    public virtual void DeleteRefToCurrencyUsedByCountry(Country relatedCountry)
    {
        if(CurrencyUsedByCountry.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        CurrencyUsedByCountry.Remove(relatedCountry);
    }

    public virtual void DeleteAllRefToCurrencyUsedByCountry()
    {
        if(CurrencyUsedByCountry.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        CurrencyUsedByCountry.Clear();
    }

    /// <summary>
    /// Currency used by ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> CurrencyUsedByMinimumCashStocks { get; private set; } = new();

    public virtual void CreateRefToCurrencyUsedByMinimumCashStocks(MinimumCashStock relatedMinimumCashStock)
    {
        CurrencyUsedByMinimumCashStocks.Add(relatedMinimumCashStock);
    }

    public virtual void DeleteRefToCurrencyUsedByMinimumCashStocks(MinimumCashStock relatedMinimumCashStock)
    {
        CurrencyUsedByMinimumCashStocks.Remove(relatedMinimumCashStock);
    }

    public virtual void DeleteAllRefToCurrencyUsedByMinimumCashStocks()
    {
        CurrencyUsedByMinimumCashStocks.Clear();
    }

    /// <summary>
    /// Currency commonly used ZeroOrMany BankNotes
    /// </summary>
    public virtual List<BankNote> CurrencyCommonBankNotes { get; set; } = new();

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRate> CurrencyExchangedFromRates { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}