// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
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
public partial class StoreSecurityPasswordsDto : AuditableEntityBase
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
}