// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingUpdateDto : BookingUpdateDtoBase
{

}

/// <summary>
/// Exchange booking and related data
/// </summary>
public partial class BookingUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Booking>
{
    /// <summary>
    /// Booking's amount exchanged from 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public virtual MoneyDto AmountFrom { get; set; } = default!;
    /// <summary>
    /// Booking's amount exchanged to 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public virtual MoneyDto AmountTo { get; set; } = default!;
    /// <summary>
    /// Booking's requested pick up date 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public virtual DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;
    /// <summary>
    /// Booking's actual pick up date 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// Booking's expiry date 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.DateTimeOffset? ExpiryDateTime { get; set; }
    /// <summary>
    /// Booking's cancelled date 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// Booking's related vat number 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "Customer is required")]
    public virtual System.Int64 CustomerId { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "VendingMachine is required")]
    public virtual System.Guid VendingMachineId { get; set; } = default!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    [Required(ErrorMessage = "Commission is required")]
    public virtual System.Int64 CommissionId { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    [Required(ErrorMessage = "Transaction is required")]
    public virtual System.Int64 TransactionId { get; set; } = default!;
}