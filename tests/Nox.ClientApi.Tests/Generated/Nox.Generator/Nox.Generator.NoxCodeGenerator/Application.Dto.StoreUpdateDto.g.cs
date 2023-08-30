// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto; 

/// <summary>
/// Stores.
/// </summary>
public partial class StoreUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
     public virtual EmailAddressUpdateDto? EmailAddress { get; set; } = null!;
}