// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class MinimumCashStock:MinimumCashStockBase
{

}
/// <summary>
/// Record for MinimumCashStock created event.
/// </summary>
public record MinimumCashStockCreated(MinimumCashStockBase MinimumCashStock) : IDomainEvent;
/// <summary>
/// Record for MinimumCashStock updated event.
/// </summary>
public record MinimumCashStockUpdated(MinimumCashStockBase MinimumCashStock) : IDomainEvent;
/// <summary>
/// Record for MinimumCashStock deleted event.
/// </summary>
public record MinimumCashStockDeleted(MinimumCashStockBase MinimumCashStock) : IDomainEvent;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public abstract class MinimumCashStockBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    /// Vending machine cash stock unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new MinimumCashStockCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new MinimumCashStockUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new MinimumCashStockDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// MinimumCashStock required by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> MinimumCashStocksRequiredByVendingMachines { get; private set; } = new();

    public virtual void CreateRefToMinimumCashStocksRequiredByVendingMachines(VendingMachine relatedVendingMachine)
    {
        MinimumCashStocksRequiredByVendingMachines.Add(relatedVendingMachine);
    }

    public virtual void DeleteRefToMinimumCashStocksRequiredByVendingMachines(VendingMachine relatedVendingMachine)
    {
        MinimumCashStocksRequiredByVendingMachines.Remove(relatedVendingMachine);
    }

    public virtual void DeleteAllRefToMinimumCashStocksRequiredByVendingMachines()
    {
        MinimumCashStocksRequiredByVendingMachines.Clear();
    }

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    public virtual Currency MinimumCashStockRelatedCurrency { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 MinimumCashStockRelatedCurrencyId { get; set; } = null!;

    public virtual void CreateRefToMinimumCashStockRelatedCurrency(Currency relatedCurrency)
    {
        MinimumCashStockRelatedCurrency = relatedCurrency;
    }

    public virtual void DeleteRefToMinimumCashStockRelatedCurrency(Currency relatedCurrency)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToMinimumCashStockRelatedCurrency()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}