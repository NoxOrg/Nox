// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public partial class RatingProgramCreateDto : RatingProgramCreateDtoBase
{

}

/// <summary>
/// Rating program for store.
/// </summary>
public abstract class RatingProgramCreateDtoBase : IEntityDto<RatingProgram>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "StoreId is required")]
    public System.Guid StoreId { get; set; } = default!;
    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public virtual System.String? Name { get; set; }
}