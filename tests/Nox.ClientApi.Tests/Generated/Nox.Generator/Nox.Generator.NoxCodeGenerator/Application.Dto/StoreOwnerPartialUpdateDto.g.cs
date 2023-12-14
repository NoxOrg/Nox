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
/// Store owners.
/// </summary>
public partial class StoreOwnerPartialUpdateDto : StoreOwnerPartialUpdateDtoBase
{

}

/// <summary>
/// Store owners
/// </summary>
public partial class StoreOwnerPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.StoreOwner>
{
    /// <summary>
    /// Owner Name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Temporary Owner Name
    /// </summary>
    public virtual System.String TemporaryOwnerName { get; set; } = default!;
    /// <summary>
    /// Vat Number
    /// </summary>
    public virtual VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address
    /// </summary>
    public virtual StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting
    /// </summary>
    public virtual TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes
    /// </summary>
    public virtual System.String? Notes { get; set; }
}