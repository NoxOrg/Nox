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
/// Country Quality Of Life Index.
/// </summary>
public partial class CountryQualityOfLifeIndexPartialUpdateDto : CountryQualityOfLifeIndexPartialUpdateDtoBase
{

}

/// <summary>
/// Country Quality Of Life Index
/// </summary>
public partial class CountryQualityOfLifeIndexPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CountryQualityOfLifeIndex>
{
    /// <summary>
    /// Rating Index
    /// </summary>
    public virtual System.Int32 IndexRating { get; set; } = default!;
}