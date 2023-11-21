// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Holiday related to country.
/// </summary>
public partial class HolidayUpsertDto : HolidayUpsertDtoBase
{

}

/// <summary>
/// Holiday related to country
/// </summary>
public abstract class HolidayUpsertDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Holiday>
{

    /// <summary>
    /// Country's holiday unique identifier
    /// </summary>
    public System.Int64? Id { get; set; }

    /// <summary>
    /// Country holiday name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    public virtual System.String Name { get; set; } = default!;

    /// <summary>
    /// Country holiday type     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Type is required")]
    public virtual System.String Type { get; set; } = default!;

    /// <summary>
    /// Country holiday date     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Date is required")]
    public virtual System.DateTime Date { get; set; } = default!;
}