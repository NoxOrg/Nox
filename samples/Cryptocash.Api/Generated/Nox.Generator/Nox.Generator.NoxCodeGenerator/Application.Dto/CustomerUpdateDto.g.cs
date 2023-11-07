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
/// Customer definition and related data.
/// </summary>
public partial class CustomerUpdateDto : IEntityDto<DomainNamespace.Customer>
{
    /// <summary>
    /// Customer's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Customer's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// Customer's email address (Required).
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Customer's street address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Customer's mobile number (Optional).
    /// </summary>
    public System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public List<System.Int64> PaymentDetailsId { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public List<System.Guid> BookingsId { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public List<System.Int64> TransactionsId { get; set; } = new();

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "Country is required")]
    public System.String CountryId { get; set; } = default!;
}