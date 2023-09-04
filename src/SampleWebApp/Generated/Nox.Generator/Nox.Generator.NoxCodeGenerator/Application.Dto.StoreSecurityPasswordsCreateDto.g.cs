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
public partial class StoreSecurityPasswordsCreateDto : StoreSecurityPasswordsUpdateDto
{
    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public StoreSecurityPasswords ToEntity()
    {
        var entity = new StoreSecurityPasswords();
        entity.Id = StoreSecurityPasswords.CreateId(Id);
        entity.Name = StoreSecurityPasswords.CreateName(Name);
        entity.SecurityCamerasPassword = StoreSecurityPasswords.CreateSecurityCamerasPassword(SecurityCamerasPassword);
        //entity.Store = Store.ToEntity();
        return entity;
    }
}