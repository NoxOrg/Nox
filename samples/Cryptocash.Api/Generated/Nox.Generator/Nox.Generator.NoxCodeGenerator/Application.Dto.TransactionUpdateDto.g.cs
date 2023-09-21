// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionUpdateDto : IEntityDto<Transaction>
{
    /// <summary>
    /// Transaction type (Required).
    /// </summary>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public System.String TransactionType { get; set; } = default!;
    /// <summary>
    /// Transaction processed datetime (Required).
    /// </summary>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;
    /// <summary>
    /// Transaction amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Transaction external reference (Required).
    /// </summary>
    [Required(ErrorMessage = "Reference is required")]
    
    public System.String Reference { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "TransactionForCustomer is required")]
    public System.Int64 TransactionForCustomerId { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    [Required(ErrorMessage = "TransactionForBooking is required")]
    public System.Guid TransactionForBookingId { get; set; } = default!;
}