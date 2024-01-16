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
/// Client of a Store.
/// </summary>
public partial class ClientCreateDto : ClientCreateDtoBase
{

}

/// <summary>
/// Client of a Store.
/// </summary>
public abstract class ClientCreateDtoBase : IEntityDto<DomainNamespace.Client>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Store Name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Client Buys in this Store ZeroOrMany Stores
    /// </summary>
    public virtual List<System.Guid> StoresId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<StoreCreateDto> Stores { get; set; } = new();
}