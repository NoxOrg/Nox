// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerCreateDto 
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
    /// Customer based in ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "CustomerBaseCountry is required")]
    public System.String CustomerBaseCountryId { get; set; } = default!;

    public Cryptocash.Domain.Customer ToEntity()
    {
        var entity = new Cryptocash.Domain.Customer();
        entity.FirstName = Cryptocash.Domain.Customer.CreateFirstName(FirstName);
        entity.LastName = Cryptocash.Domain.Customer.CreateLastName(LastName);
        entity.EmailAddress = Cryptocash.Domain.Customer.CreateEmailAddress(EmailAddress);
        entity.Address = Cryptocash.Domain.Customer.CreateAddress(Address);
        if (MobileNumber is not null)entity.MobileNumber = Cryptocash.Domain.Customer.CreateMobileNumber(MobileNumber.NonNullValue<System.String>());
        //entity.PaymentDetails = PaymentDetails.Select(dto => dto.ToEntity()).ToList();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.Transactions = Transactions.Select(dto => dto.ToEntity()).ToList();
        //entity.Country = Country.ToEntity();
        return entity;
    }
}