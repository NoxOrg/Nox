// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryTimeZoneKeyDto(System.String keyId);

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
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.CountryTimeZoneMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Country's related time zone code
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Time Zone Name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Name { get; set; }
}