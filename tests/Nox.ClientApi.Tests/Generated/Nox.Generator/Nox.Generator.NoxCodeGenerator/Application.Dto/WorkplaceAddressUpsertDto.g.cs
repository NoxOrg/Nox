// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace Address.
/// </summary>
public partial class WorkplaceAddressUpsertDto : WorkplaceAddressUpsertDtoBase
{

}

/// <summary>
/// Workplace Address
/// </summary>
public abstract class WorkplaceAddressUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// 
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Address line     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "AddressLine is required")]
    public virtual System.String? AddressLine { get; set; }
}