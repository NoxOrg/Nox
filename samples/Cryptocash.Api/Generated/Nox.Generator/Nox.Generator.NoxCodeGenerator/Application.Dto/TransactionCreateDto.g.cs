// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionCreateDto : TransactionCreateDtoBase
{

}

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionCreateDtoBase 
{/// <summary>
    /// Customer transaction unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Transaction type     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public virtual System.String? TransactionType { get; set; }
    /// <summary>
    /// Transaction processed datetime     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public virtual System.DateTimeOffset? ProcessedOnDateTime { get; set; }
    /// <summary>
    /// Transaction amount     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto? Amount { get; set; }
    /// <summary>
    /// Transaction external reference     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Reference is required")]
    
    public virtual System.String? Reference { get; set; }

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    public System.Guid? CustomerId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CustomerCreateDto? Customer { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    public System.Guid? BookingId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual BookingCreateDto? Booking { get; set; } = default!;
}