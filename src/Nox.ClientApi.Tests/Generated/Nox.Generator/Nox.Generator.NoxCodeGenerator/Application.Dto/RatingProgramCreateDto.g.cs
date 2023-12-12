// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Rating program for store.
/// </summary>
public partial class RatingProgramCreateDto : RatingProgramCreateDtoBase
{

}

/// <summary>
/// Rating program for store.
/// </summary>
public abstract class RatingProgramCreateDtoBase : IEntityDto<DomainNamespace.RatingProgram>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "StoreId is required")]
    public System.Guid? StoreId { get; set; }
    /// <summary>
    /// Rating Program Name     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? Name { get; set; }
}