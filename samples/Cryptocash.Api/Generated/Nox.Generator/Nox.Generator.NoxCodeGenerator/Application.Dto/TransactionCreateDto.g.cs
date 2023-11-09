// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class TransactionCreateDto : TransactionCreateDtoBase
{

}

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionCreateDtoBase : IEntityDto<DomainNamespace.Transaction>
{
    /// <summary>
    /// Transaction type 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public virtual System.String TransactionType { get; set; } = default!;
    /// <summary>
    /// Transaction processed datetime 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public virtual System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;
    /// <summary>
    /// Transaction amount 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Transaction external reference 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Reference is required")]
    
    public virtual System.String Reference { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    public System.Int64? CustomerId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CustomerCreateDto? Customer { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    public System.Guid? BookingId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual BookingCreateDto? Booking { get; set; } = default!;
}