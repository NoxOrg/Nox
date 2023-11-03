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

internal partial class VendingMachine : VendingMachineBase, IEntityHaveDomainEvents
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
/// Record for VendingMachine created event.
/// </summary>
internal record VendingMachineCreated(VendingMachine VendingMachine) :  IDomainEvent, INotification;
/// <summary>
/// Record for VendingMachine updated event.
/// </summary>
internal record VendingMachineUpdated(VendingMachine VendingMachine) : IDomainEvent, INotification;
/// <summary>
/// Record for VendingMachine deleted event.
/// </summary>
internal record VendingMachineDeleted(VendingMachine VendingMachine) : IDomainEvent, INotification;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
internal abstract partial class VendingMachineBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Vending machine unique identifier (Required).
    /// </summary>
    public Nox.Types.Guid Id {get; set;} = null!;
         /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid guid)
    	{
    		if(System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid);
    		}
    	}

    /// <summary>
    /// Vending machine mac address (Required).
    /// </summary>
    public Nox.Types.MacAddress MacAddress { get; set; } = null!;

    /// <summary>
    /// Vending machine public ip (Required).
    /// </summary>
    public Nox.Types.IpAddress PublicIp { get; set; } = null!;

    /// <summary>
    /// Vending machine geo location (Required).
    /// </summary>
    public Nox.Types.LatLong GeoLocation { get; set; } = null!;

    /// <summary>
    /// Vending machine street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress StreetAddress { get; set; } = null!;

    /// <summary>
    /// Vending machine serial number (Required).
    /// </summary>
    public Nox.Types.Text SerialNumber { get; set; } = null!;

    /// <summary>
    /// Vending machine installation area (Optional).
    /// </summary>
    public Nox.Types.Area? InstallationFootPrint { get; set; } = null!;

    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation (Optional).
    /// </summary>
    public Nox.Types.Money? RentPerSquareMetre { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(VendingMachine vendingMachine)
	{
		InternalDomainEvents.Add(new VendingMachineCreated(vendingMachine));
    }
	
	protected virtual void InternalRaiseUpdateEvent(VendingMachine vendingMachine)
	{
		InternalDomainEvents.Add(new VendingMachineUpdated(vendingMachine));
    }
	
	protected virtual void InternalRaiseDeleteEvent(VendingMachine vendingMachine)
	{
		InternalDomainEvents.Add(new VendingMachineDeleted(vendingMachine));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    public virtual void CreateRefToCountry(Country relatedCountry)
    {
        Country = relatedCountry;
    }

    public virtual void DeleteRefToCountry(Country relatedCountry)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToCountry()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    public virtual LandLord LandLord { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity LandLord
    /// </summary>
    public Nox.Types.AutoNumber LandLordId { get; set; } = null!;

    public virtual void CreateRefToLandLord(LandLord relatedLandLord)
    {
        LandLord = relatedLandLord;
    }

    public virtual void DeleteRefToLandLord(LandLord relatedLandLord)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToLandLord()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; private set; } = new();

    public virtual void CreateRefToBookings(Booking relatedBooking)
    {
        Bookings.Add(relatedBooking);
    }

    public virtual void UpdateRefToBookings(List<Booking> relatedBooking)
    {
        Bookings.Clear();
        Bookings.AddRange(relatedBooking);
    }

    public virtual void DeleteRefToBookings(Booking relatedBooking)
    {
        Bookings.Remove(relatedBooking);
    }

    public virtual void DeleteAllRefToBookings()
    {
        Bookings.Clear();
    }

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<CashStockOrder> CashStockOrders { get; private set; } = new();

    public virtual void CreateRefToCashStockOrders(CashStockOrder relatedCashStockOrder)
    {
        CashStockOrders.Add(relatedCashStockOrder);
    }

    public virtual void UpdateRefToCashStockOrders(List<CashStockOrder> relatedCashStockOrder)
    {
        CashStockOrders.Clear();
        CashStockOrders.AddRange(relatedCashStockOrder);
    }

    public virtual void DeleteRefToCashStockOrders(CashStockOrder relatedCashStockOrder)
    {
        CashStockOrders.Remove(relatedCashStockOrder);
    }

    public virtual void DeleteAllRefToCashStockOrders()
    {
        CashStockOrders.Clear();
    }

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
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
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}