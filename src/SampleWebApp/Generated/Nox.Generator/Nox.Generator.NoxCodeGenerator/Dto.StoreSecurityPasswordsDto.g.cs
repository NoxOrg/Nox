// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public class StoreSecurityPasswordsKeyDto
{

    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    [Key]
    public System.String Id { get; set; } = default!;
}

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswordsDto : StoreSecurityPasswordsKeyDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String SecurityCamerasPassword { get; set; } = default!;

    /// <summary>
    /// StoreSecurityPasswords Store with this set of passwords ExactlyOne Stores
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string StoreId { get; set; } = null!;
    public virtual StoreDto Store { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}