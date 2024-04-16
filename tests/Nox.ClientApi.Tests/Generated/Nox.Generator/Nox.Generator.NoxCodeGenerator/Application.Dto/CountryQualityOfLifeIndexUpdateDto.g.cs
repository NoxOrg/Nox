// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class CountryQualityOfLifeIndexUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Rating Index     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "IndexRating is required")]
    
    public virtual System.Int32? IndexRating { get; set; }
}