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

public record CountryTimeZoneKeyDto(System.Int64 keyId);

public partial class CountryTimeZoneDto : CountryTimeZoneDtoBase
{

}

/// <summary>
/// Time zone related to country.
/// </summary>
public abstract class CountryTimeZoneDtoBase : EntityDtoBase, IEntityDto<CountryTimeZone>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TimeZoneCode is not null)
            ExecuteActionAndCollectValidationExceptions("TimeZoneCode", () => Cryptocash.Domain.CountryTimeZoneMetadata.CreateTimeZoneCode(this.TimeZoneCode.NonNullValue<System.String>()), result);
        else
            result.Add("TimeZoneCode", new [] { "TimeZoneCode is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public System.String TimeZoneCode { get; set; } = default!;
}