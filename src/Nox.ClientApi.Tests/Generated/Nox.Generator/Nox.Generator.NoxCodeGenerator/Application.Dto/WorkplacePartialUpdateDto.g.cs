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
/// Workplace.
/// </summary>
public partial class WorkplacePartialUpdateDto : WorkplacePartialUpdateDtoBase
{

}

/// <summary>
/// Workplace
/// </summary>
public partial class WorkplacePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Workplace>
{
    /// <summary>
    /// Workplace Name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Workplace Description
    /// </summary>
    public virtual System.String? Description { get; set; }
    /// <summary>
    /// Workplace Ownership
    /// </summary>
    public virtual System.Int32? Ownership { get; set; }
    /// <summary>
    /// Workplace Type
    /// </summary>
    public virtual System.Int32? Type { get; set; }
}