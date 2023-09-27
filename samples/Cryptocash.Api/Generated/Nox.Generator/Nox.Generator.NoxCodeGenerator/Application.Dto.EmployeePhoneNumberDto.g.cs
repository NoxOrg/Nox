
// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeePhoneNumberKeyDto(System.Int64 keyId);

public partial class EmployeePhoneNumberDto : EmployeePhoneNumberDtoBase
{

}

/// <summary>
/// Employee phone number and related data.
/// </summary>
public abstract class EmployeePhoneNumberDtoBase : EntityDtoBase, IEntityDto<EmployeePhoneNumber>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.PhoneNumberType is not null)
            TryGetValidationExceptions("PhoneNumberType", () => Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(this.PhoneNumberType.NonNullValue<System.String>()), result);
        else
            result.Add("PhoneNumberType", new [] { "PhoneNumberType is Required." });
    
        if (this.PhoneNumber is not null)
            TryGetValidationExceptions("PhoneNumber", () => Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(this.PhoneNumber.NonNullValue<System.String>()), result);
        else
            result.Add("PhoneNumber", new [] { "PhoneNumber is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Employee's phone number identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    public System.String PhoneNumberType { get; set; } = default!;

    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    public System.String PhoneNumber { get; set; } = default!;
}