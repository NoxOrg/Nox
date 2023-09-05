// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswordsCreateDto 
{
    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;    
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
    public System.String StoreRelId { get; set; } = default!;

    public SampleWebApp.Domain.StoreSecurityPasswords ToEntity()
    {
        var entity = new SampleWebApp.Domain.StoreSecurityPasswords();
        entity.Id = StoreSecurityPasswords.CreateId(Id);
        entity.Name = SampleWebApp.Domain.StoreSecurityPasswords.CreateName(Name);
        entity.SecurityCamerasPassword = SampleWebApp.Domain.StoreSecurityPasswords.CreateSecurityCamerasPassword(SecurityCamerasPassword);
        //entity.Store = Store.ToEntity();
        return entity;
    }
}