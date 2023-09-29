// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class TransactionCreateDto : TransactionCreateDtoBase
{

}

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionCreateDtoBase : IEntityDto<Transaction>
{
    /// <summary>
    /// Transaction type (Required).
    /// </summary>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public virtual System.String TransactionType { get; set; } = default!;
    /// <summary>
    /// Transaction processed datetime (Required).
    /// </summary>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public virtual System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;
    /// <summary>
    /// Transaction amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Transaction external reference (Required).
    /// </summary>
    [Required(ErrorMessage = "Reference is required")]
    
    public virtual System.String Reference { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    public System.Int64? TransactionForCustomerId { get; set; } = default!;
    public virtual CustomerCreateDto? TransactionForCustomer { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    public System.Guid? TransactionForBookingId { get; set; } = default!;
    public virtual BookingCreateDto? TransactionForBooking { get; set; } = default!;
}