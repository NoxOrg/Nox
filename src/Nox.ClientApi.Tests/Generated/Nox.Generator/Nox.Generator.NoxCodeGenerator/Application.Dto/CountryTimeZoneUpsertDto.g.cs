// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Time zone related to country.
/// </summary>
public partial class CountryTimeZoneUpsertDto : CountryTimeZoneUpsertDtoBase
{

}

/// <summary>
/// Time zone related to country
/// </summary>
public abstract class CountryTimeZoneUpsertDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CountryTimeZone>
{

    /// <summary>
    /// Country's related time zone code
    /// </summary>
    public System.String? Id { get; set; }

    /// <summary>
    /// Time Zone Name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Name { get; set; }
}