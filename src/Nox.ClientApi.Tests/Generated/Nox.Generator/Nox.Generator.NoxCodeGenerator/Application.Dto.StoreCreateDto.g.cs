// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto : IEntityCreateDto <Store>
{    
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Store Store owner relationship ZeroOrOne StoreOwners
    /// </summary>
    
    public System.String? OwnerRelId { get; set; } = default!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressCreateDto? EmailAddress { get; set; } = null!;

    public ClientApi.Domain.Store ToEntity()
    {
        var entity = new ClientApi.Domain.Store();
        entity.Name = ClientApi.Domain.Store.CreateName(Name);
        //entity.StoreOwner = StoreOwner?.ToEntity();
        entity.EmailAddress = EmailAddress?.ToEntity();
        return entity;
    }
}