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
/// Stores.
/// </summary>
[AutoMap(typeof(StoreCreateDto))]
public partial class StoreDto : AuditableEntityBase
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Store address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Store location coordinates (Required).
    /// </summary>
    public LatLongDto LatLong { get; set; } = default!;

    /// <summary>
    /// Store phone number (Required).
    /// </summary>
    public System.String Phone { get; set; } = default!;
}