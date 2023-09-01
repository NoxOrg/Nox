// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CustomerKeyDto(System.Int64 keyId);

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerDto
{

    /// <summary>
    /// Customer's unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Customer's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Customer's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Customer's email address (Required).
    /// </summary>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Customer's street address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Customer's mobile number (Optional).
    /// </summary>
    public System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer Customer's payment details ZeroOrMany CustomerPaymentDetails
    /// </summary>
    public virtual List<CustomerPaymentDetailsDto> CustomerPaymentDetails { get; set; } = new();

    /// <summary>
    /// Customer Customer's booking ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();

    /// <summary>
    /// Customer Customer's transaction ZeroOrMany CustomerTransactions
    /// </summary>
    public virtual List<CustomerTransactionDto> CustomerTransactions { get; set; } = new();

    /// <summary>
    /// Customer Customer's country ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String CountryId { get; set; } = default!;
    public virtual CountryDto Country { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public Customer ToEntity()
    {
        var entity = new Customer();
        entity.Id = Customer.CreateId(Id);
        entity.FirstName = Customer.CreateFirstName(FirstName);
        entity.LastName = Customer.CreateLastName(LastName);
        entity.EmailAddress = Customer.CreateEmailAddress(EmailAddress);
        entity.Address = Customer.CreateAddress(Address);
        if (MobileNumber is not null)entity.MobileNumber = Customer.CreateMobileNumber(MobileNumber.NonNullValue<System.String>());
        entity.CustomerPaymentDetails = CustomerPaymentDetails.Select(dto => dto.ToEntity()).ToList();
        entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        entity.CustomerTransactions = CustomerTransactions.Select(dto => dto.ToEntity()).ToList();
        entity.Country = Country.ToEntity();
        return entity;
    }

}