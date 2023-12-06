// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = CryptocashIntegration.Domain;

namespace CryptocashIntegration.Application.Dto;



/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryQueryToTablePartialUpdateDto : CountryQueryToTablePartialUpdateDtoBase
{

}

/// <summary>
/// Country and related data
/// </summary>
public partial class CountryQueryToTablePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CountryQueryToTable>
{
    /// <summary>
    /// Country's name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Country's population
    /// </summary>
    public virtual System.Int32 Population { get; set; } = default!;
}