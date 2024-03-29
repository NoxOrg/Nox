﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record CustomerKeyDto(System.Guid keyId);

/// <summary>
/// Update Customer
/// Customer definition and related data.
/// </summary>
public partial class CustomerDto : CustomerDtoBase
{

}

/// <summary>
/// Customer definition and related data.
/// </summary>
public abstract class CustomerDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.FirstName is not null)
            CollectValidationExceptions("FirstName", () => CustomerMetadata.CreateFirstName(this.FirstName.NonNullValue<System.String>()), result);
        else
            result.Add("FirstName", new [] { "FirstName is Required." });
    
        if (this.LastName is not null)
            CollectValidationExceptions("LastName", () => CustomerMetadata.CreateLastName(this.LastName.NonNullValue<System.String>()), result);
        else
            result.Add("LastName", new [] { "LastName is Required." });
    
        if (this.EmailAddress is not null)
            CollectValidationExceptions("EmailAddress", () => CustomerMetadata.CreateEmailAddress(this.EmailAddress.NonNullValue<System.String>()), result);
        else
            result.Add("EmailAddress", new [] { "EmailAddress is Required." });
    
        if (this.Address is not null)
            CollectValidationExceptions("Address", () => CustomerMetadata.CreateAddress(this.Address.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("Address", new [] { "Address is Required." });
    
        if (this.MobileNumber is not null)
            CollectValidationExceptions("MobileNumber", () => CustomerMetadata.CreateMobileNumber(this.MobileNumber.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Customer's unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Customer's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Customer's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Customer's email address     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Customer's street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Customer's mobile number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetailDto> PaymentDetails { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<TransactionDto> Transactions { get; set; } = new();

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CountryId { get; set; } = default!;
    public virtual CountryDto? Country { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}