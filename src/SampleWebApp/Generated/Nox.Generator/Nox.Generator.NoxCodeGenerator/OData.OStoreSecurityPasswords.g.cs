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

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
[AutoMap(typeof(StoreSecurityPasswordsDto))]
public partial class OStoreSecurityPasswords : AuditableEntityBase
{

    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    public String Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public String Name { get; set; } =default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public String SecurityCamerasPassword { get; set; } =default!;

    /// <summary>
    /// StoreSecurityPasswords Store with this set of passwords ExactlyOne Stores
    /// </summary>
    public virtual OStore Store { get; set; } = null!;
}