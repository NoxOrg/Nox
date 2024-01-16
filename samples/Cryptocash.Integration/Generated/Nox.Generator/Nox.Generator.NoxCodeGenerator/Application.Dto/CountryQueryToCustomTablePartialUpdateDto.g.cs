// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace CryptocashIntegration.Application.Dto;



/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryQueryToCustomTablePartialUpdateDto : CountryQueryToCustomTablePartialUpdateDtoBase
{

}

/// <summary>
/// Country and related data
/// </summary>
public partial class CountryQueryToCustomTablePartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Country's name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Country's population
    /// </summary>
    public virtual System.Int32 Population { get; set; } = default!;
    /// <summary>
    /// The date on which the country record was created
    /// </summary>
    public virtual System.DateTimeOffset CreateDate { get; set; } = default!;
    /// <summary>
    /// The date on which the country record was last updated
    /// </summary>
    public virtual System.DateTimeOffset? EditDate { get; set; }
}