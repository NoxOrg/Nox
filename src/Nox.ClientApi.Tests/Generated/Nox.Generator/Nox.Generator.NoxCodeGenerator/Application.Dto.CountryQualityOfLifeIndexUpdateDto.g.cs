// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
public partial class CountryQualityOfLifeIndexUpdateDto : IEntityDto<CountryQualityOfLifeIndex>
{
    /// <summary>
    /// Rating Index (Required).
    /// </summary>
    [Required(ErrorMessage = "IndexRating is required")]
    
    public System.Int32 IndexRating { get; set; } = default!;
}