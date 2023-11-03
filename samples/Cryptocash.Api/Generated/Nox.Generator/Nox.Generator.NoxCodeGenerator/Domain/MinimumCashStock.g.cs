// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class MinimumCashStock : MinimumCashStockBase, IEntityHaveDomainEvents
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
/// Record for MinimumCashStock created event.
/// </summary>
internal record MinimumCashStockCreated(MinimumCashStock MinimumCashStock) :  IDomainEvent, INotification;
/// <summary>
/// Record for MinimumCashStock updated event.
/// </summary>
internal record MinimumCashStockUpdated(MinimumCashStock MinimumCashStock) : IDomainEvent, INotification;
/// <summary>
/// Record for MinimumCashStock deleted event.
/// </summary>
internal record MinimumCashStockDeleted(MinimumCashStock MinimumCashStock) : IDomainEvent, INotification;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
internal abstract partial class MinimumCashStockBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine cash stock unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(MinimumCashStock minimumCashStock)
	{
		InternalDomainEvents.Add(new MinimumCashStockCreated(minimumCashStock));
    }
	
	protected virtual void InternalRaiseUpdateEvent(MinimumCashStock minimumCashStock)
	{
		InternalDomainEvents.Add(new MinimumCashStockUpdated(minimumCashStock));
    }
	
	protected virtual void InternalRaiseDeleteEvent(MinimumCashStock minimumCashStock)
	{
		InternalDomainEvents.Add(new MinimumCashStockDeleted(minimumCashStock));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// MinimumCashStock required by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachines { get; private set; } = new();

    public virtual void CreateRefToVendingMachines(VendingMachine relatedVendingMachine)
    {
        VendingMachines.Add(relatedVendingMachine);
    }

    public virtual void UpdateRefToVendingMachines(List<VendingMachine> relatedVendingMachine)
    {
        VendingMachines.Clear();
        VendingMachines.AddRange(relatedVendingMachine);
    }

    public virtual void DeleteRefToVendingMachines(VendingMachine relatedVendingMachine)
    {
        VendingMachines.Remove(relatedVendingMachine);
    }

    public virtual void DeleteAllRefToVendingMachines()
    {
        VendingMachines.Clear();
    }

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    public virtual Currency Currency { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CurrencyId { get; set; } = null!;

    public virtual void CreateRefToCurrency(Currency relatedCurrency)
    {
        Currency = relatedCurrency;
    }

    public virtual void DeleteRefToCurrency(Currency relatedCurrency)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCurrency()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}