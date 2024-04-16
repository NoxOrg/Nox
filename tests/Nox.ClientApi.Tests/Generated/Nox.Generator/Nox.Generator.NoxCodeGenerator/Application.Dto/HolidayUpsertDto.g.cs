// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Holiday related to country.
/// </summary>
public partial class HolidayUpsertDto : HolidayUpsertDtoBase
{

}

/// <summary>
/// Holiday related to country
/// </summary>
public abstract class HolidayUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// Country's holiday unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Country holiday name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Country holiday type     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Type { get; set; }

    /// <summary>
    /// Country holiday date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTime? Date { get; set; }
}