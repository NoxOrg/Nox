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
/// Description for store.
/// </summary>
public partial class StoreDescriptionUpdateDto : IEntityDto<StoreDescription>
{
    /// <summary>
    /// Store Decsription (Optional).
    /// </summary>
    public System.String? Description { get; set; }
}