// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record EmployeePhoneNumberKeyDto(System.Int64 keyId);

/// <summary>
/// Update EmployeePhoneNumber
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberDto : EmployeePhoneNumberDtoBase
{

}

/// <summary>
/// Employee phone number and related data.
/// </summary>
public abstract class EmployeePhoneNumberDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.PhoneNumberType is not null)
            CollectValidationExceptions("PhoneNumberType", () => EmployeePhoneNumberMetadata.CreatePhoneNumberType(this.PhoneNumberType.NonNullValue<System.String>()), result);
        else
            result.Add("PhoneNumberType", new [] { "PhoneNumberType is Required." });
    
        if (this.PhoneNumber is not null)
            CollectValidationExceptions("PhoneNumber", () => EmployeePhoneNumberMetadata.CreatePhoneNumber(this.PhoneNumber.NonNullValue<System.String>()), result);
        else
            result.Add("PhoneNumber", new [] { "PhoneNumber is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Employee's phone number identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's phone number type     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PhoneNumberType { get; set; } = default!;

    /// <summary>
    /// Employee's phone number     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PhoneNumber { get; set; } = default!;
}