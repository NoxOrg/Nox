// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

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
    /// Country's time zone unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Country's related time zone code     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TimeZoneCode is required")]
    public virtual System.String TimeZoneCode { get; set; } = default!;
}