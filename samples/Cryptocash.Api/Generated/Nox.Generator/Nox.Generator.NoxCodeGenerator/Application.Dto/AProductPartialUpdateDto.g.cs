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
/// ReferenceNumberEntity.
/// </summary>
public partial class AProductPartialUpdateDto : AProductPartialUpdateDtoBase
{

}

/// <summary>
/// ReferenceNumberEntity
/// </summary>
public partial class AProductPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.AProduct>
{
    /// <summary>
    /// ReferenceNumber
    /// </summary>
    public virtual System.Guid MyGuid { get; set; } = default!;
}