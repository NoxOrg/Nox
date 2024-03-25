// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace ClientApi.Application.Dto;

public record WorkplaceAddressKeyDto(System.Guid keyId);

/// <summary>
/// Update WorkplaceAddress
/// Workplace Address.
/// </summary>
public partial class WorkplaceAddressDto : WorkplaceAddressDtoBase
{

}

/// <summary>
/// Workplace Address.
/// </summary>
public abstract class WorkplaceAddressDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.AddressLine is not null)
            CollectValidationExceptions("AddressLine", () => WorkplaceAddressMetadata.CreateAddressLine(this.AddressLine.NonNullValue<System.String>()), result);
        else
            result.Add("AddressLine", new [] { "AddressLine is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Address line     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String AddressLine { get; set; } = default!;
}