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

public partial class CustomerCreateDto : CustomerCreateDtoBase
{

}

/// <summary>
/// Customer definition and related data.
/// </summary>
public abstract class CustomerCreateDtoBase : IEntityDto<Customer>
{
    /// <summary>
    /// Customer's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Customer's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Customer's email address (Required).
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Customer's street address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Customer's mobile number (Optional).
    /// </summary>
    public virtual System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetailCreateDto> CustomerRelatedPaymentDetails { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingCreateDto> CustomerRelatedBookings { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<TransactionCreateDto> CustomerRelatedTransactions { get; set; } = new();

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "CustomerBaseCountry is required")]
    public virtual CountryCreateDto CustomerBaseCountry { get; set; } = null!;
}