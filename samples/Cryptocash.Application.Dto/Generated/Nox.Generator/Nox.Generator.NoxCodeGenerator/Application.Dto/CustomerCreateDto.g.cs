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
/// Customer definition and related data.
/// </summary>
public partial class CustomerCreateDto : CustomerCreateDtoBase
{

}

/// <summary>
/// Customer definition and related data.
/// </summary>
public abstract class CustomerCreateDtoBase 
{/// <summary>
    /// Customer's unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Customer's first name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String? FirstName { get; set; }
    /// <summary>
    /// Customer's last name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String? LastName { get; set; }
    /// <summary>
    /// Customer's email address     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String? EmailAddress { get; set; }
    /// <summary>
    /// Customer's street address     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto? Address { get; set; }
    /// <summary>
    /// Customer's mobile number     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<System.Int64> PaymentDetailsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<PaymentDetailCreateDto> PaymentDetails { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<System.Guid> BookingsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<BookingCreateDto> Bookings { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<System.Guid> TransactionsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TransactionCreateDto> Transactions { get; set; } = new();

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    public System.String? CountryId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CountryCreateDto? Country { get; set; } = default!;
}