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
/// Client of a Store.
/// </summary>
public partial class ClientPartialUpdateDto : ClientPartialUpdateDtoBase
{

}

/// <summary>
/// Client of a Store
/// </summary>
public partial class ClientPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Client>
{
    /// <summary>
    /// Store Name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
}