// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
[AutoMap(typeof(StoreSecurityPasswordsCreateDto))]
public partial class OStoreSecurityPasswords : AuditableEntityBase
{

    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    public System.String Id { get; set; } = null!;

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
    public virtual OStore Store { get; set; } = null!;
}