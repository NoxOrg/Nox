// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswordsUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "SecurityCamerasPassword is required")]
    
    public System.String SecurityCamerasPassword { get; set; } = default!;

    /// <summary>
    /// StoreSecurityPasswords Store with this set of passwords ExactlyOne Stores
    /// </summary>
    [Required(ErrorMessage = "StoreRel is required")]
    public System.String StoreId { get; set; } = default!;
}