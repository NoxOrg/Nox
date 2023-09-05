﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record StoreSecurityPasswordsKeyDto(System.String keyId);

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswordsDto
{

    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

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
    public System.String StoreId { get; set; } = default!;
    public virtual StoreDto Store { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }    
}