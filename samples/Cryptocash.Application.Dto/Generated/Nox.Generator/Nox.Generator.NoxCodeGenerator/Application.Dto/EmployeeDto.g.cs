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

public record EmployeeKeyDto(System.Guid keyId);

/// <summary>
/// Update Employee
/// Employee definition and related data.
/// </summary>
public partial class EmployeeDto : EmployeeDtoBase
{

}

/// <summary>
/// Employee definition and related data.
/// </summary>
public abstract class EmployeeDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.FirstName is not null)
            CollectValidationExceptions("FirstName", () => EmployeeMetadata.CreateFirstName(this.FirstName.NonNullValue<System.String>()), result);
        else
            result.Add("FirstName", new [] { "FirstName is Required." });
    
        if (this.LastName is not null)
            CollectValidationExceptions("LastName", () => EmployeeMetadata.CreateLastName(this.LastName.NonNullValue<System.String>()), result);
        else
            result.Add("LastName", new [] { "LastName is Required." });
    
        if (this.EmailAddress is not null)
            CollectValidationExceptions("EmailAddress", () => EmployeeMetadata.CreateEmailAddress(this.EmailAddress.NonNullValue<System.String>()), result);
        else
            result.Add("EmailAddress", new [] { "EmailAddress is Required." });
    
        if (this.Address is not null)
            CollectValidationExceptions("Address", () => EmployeeMetadata.CreateAddress(this.Address.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("Address", new [] { "Address is Required." });
    
        CollectValidationExceptions("FirstWorkingDay", () => EmployeeMetadata.CreateFirstWorkingDay(this.FirstWorkingDay), result);
    
        if (this.LastWorkingDay is not null)
            CollectValidationExceptions("LastWorkingDay", () => EmployeeMetadata.CreateLastWorkingDay(this.LastWorkingDay.NonNullValue<System.DateTime>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Employee's unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Employee's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Employee's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Employee's email address     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Employee's street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Employee's first working day     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTime FirstWorkingDay { get; set; } = default!;

    /// <summary>
    /// Employee's last working day     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee reviewing ZeroOrOne CashStockOrders
    /// </summary>
    public virtual CashStockOrderDto? CashStockOrder { get; set; } = null!;

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}