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
/// Currency and related data.
/// </summary>
public partial class CurrencyPartialUpdateDto : CurrencyPartialUpdateDtoBase
{

}

/// <summary>
/// Currency and related data
/// </summary>
public partial class CurrencyPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Currency>
{
    /// <summary>
    /// Currency's name
    /// </summary>
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Currency's symbol
    /// </summary>
    public virtual System.String? Symbol { get; set; }
}