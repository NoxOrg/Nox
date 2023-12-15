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
public partial class AProductUpdateDto : AProductUpdateDtoBase
{

}

/// <summary>
/// ReferenceNumberEntity
/// </summary>
public partial class AProductUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.AProduct>
{
    /// <summary>
    /// ReferenceNumber     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "MyGuid is required")]
    
    public virtual System.Guid? MyGuid { get; set; }
}