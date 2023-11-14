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
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionUpdateDto : TransactionUpdateDtoBase
{

}

/// <summary>
/// Customer transaction log and related data
/// </summary>
public partial class TransactionUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Transaction>
{
    /// <summary>
    /// Transaction type 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public virtual System.String TransactionType { get; set; } = default!;
    /// <summary>
    /// Transaction processed datetime 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public virtual System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;
    /// <summary>
    /// Transaction amount 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Transaction external reference 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Reference is required")]
    
    public virtual System.String Reference { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "Customer is required")]
    public virtual System.Int64 CustomerId { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    [Required(ErrorMessage = "Booking is required")]
    public virtual System.Guid BookingId { get; set; } = default!;
}