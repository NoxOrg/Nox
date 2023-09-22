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

public partial class StoreDescriptionCreateDto : StoreDescriptionCreateDtoBase
{

}

/// <summary>
/// Description for store.
/// </summary>
public abstract class StoreDescriptionCreateDtoBase : IEntityDto<StoreDescription>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "StoreId is required")]
    public System.Guid StoreId { get; set; } = default!;
    /// <summary>
    /// Store Decsription (Optional).
    /// </summary>
    public virtual System.String? Description { get; set; }
}