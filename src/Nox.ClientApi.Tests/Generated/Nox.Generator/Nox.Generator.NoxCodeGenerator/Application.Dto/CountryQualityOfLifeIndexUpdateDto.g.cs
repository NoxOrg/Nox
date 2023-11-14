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
public partial class CountryQualityOfLifeIndexUpdateDto : CountryQualityOfLifeIndexUpdateDtoBase
{

}

/// <summary>
/// Country Quality Of Life Index
/// </summary>
public partial class CountryQualityOfLifeIndexUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CountryQualityOfLifeIndex>
{
    /// <summary>
    /// Rating Index 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "IndexRating is required")]
    
    public virtual System.Int32 IndexRating { get; set; } = default!;
}