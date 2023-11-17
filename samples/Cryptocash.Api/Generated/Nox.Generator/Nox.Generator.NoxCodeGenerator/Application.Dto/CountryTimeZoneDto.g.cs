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

public record CountryTimeZoneKeyDto(System.Int64 keyId);

/// <summary>
/// Update CountryTimeZone
/// Time zone related to country.
/// </summary>
public partial class CountryTimeZoneDto : CountryTimeZoneDtoBase
{

}

/// <summary>
/// Time zone related to country.
/// </summary>
public abstract class CountryTimeZoneDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.CountryTimeZone>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TimeZoneCode is not null)
            ExecuteActionAndCollectValidationExceptions("TimeZoneCode", () => DomainNamespace.CountryTimeZoneMetadata.CreateTimeZoneCode(this.TimeZoneCode.NonNullValue<System.String>()), result);
        else
            result.Add("TimeZoneCode", new [] { "TimeZoneCode is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country's time zone unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country's related time zone code     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String TimeZoneCode { get; set; } = default!;
}