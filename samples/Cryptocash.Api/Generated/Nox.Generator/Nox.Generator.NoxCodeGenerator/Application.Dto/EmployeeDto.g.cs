// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeeKeyDto(System.Int64 keyId);

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
public abstract class EmployeeDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Employee>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.FirstName is not null)
            ExecuteActionAndCollectValidationExceptions("FirstName", () => DomainNamespace.EmployeeMetadata.CreateFirstName(this.FirstName.NonNullValue<System.String>()), result);
        else
            result.Add("FirstName", new [] { "FirstName is Required." });
    
        if (this.LastName is not null)
            ExecuteActionAndCollectValidationExceptions("LastName", () => DomainNamespace.EmployeeMetadata.CreateLastName(this.LastName.NonNullValue<System.String>()), result);
        else
            result.Add("LastName", new [] { "LastName is Required." });
    
        if (this.EmailAddress is not null)
            ExecuteActionAndCollectValidationExceptions("EmailAddress", () => DomainNamespace.EmployeeMetadata.CreateEmailAddress(this.EmailAddress.NonNullValue<System.String>()), result);
        else
            result.Add("EmailAddress", new [] { "EmailAddress is Required." });
    
        if (this.Address is not null)
            ExecuteActionAndCollectValidationExceptions("Address", () => DomainNamespace.EmployeeMetadata.CreateAddress(this.Address.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("Address", new [] { "Address is Required." });
    
        ExecuteActionAndCollectValidationExceptions("FirstWorkingDay", () => DomainNamespace.EmployeeMetadata.CreateFirstWorkingDay(this.FirstWorkingDay), result);
    
        if (this.LastWorkingDay is not null)
            ExecuteActionAndCollectValidationExceptions("LastWorkingDay", () => DomainNamespace.EmployeeMetadata.CreateLastWorkingDay(this.LastWorkingDay.NonNullValue<System.DateTime>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Employee's unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's first name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Employee's last name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Employee's email address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Employee's street address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Employee's first working day 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.DateTime FirstWorkingDay { get; set; } = default!;

    /// <summary>
    /// Employee's last working day 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee reviewing ZeroOrOne CashStockOrders
    /// </summary>
    public virtual CashStockOrderDto? CashStockOrder { get; set; } = null!;

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberDto> EmployeeContactPhoneNumbers { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}