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
/// Vending machines.
/// </summary>
[AutoMap(typeof(VendingMachineCreateDto))]
public partial class VendingMachineDto : AuditableEntityBase
{

    /// <summary>
    /// Vending machine Primary Key (Required).
    /// </summary>
    public System.UInt64 Id { get; set; } = default!;

    /// <summary>
    /// Vending machine Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Vending machine's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Vending machine' location coordinates (Required).
    /// </summary>
    public LatLongDto LatLong { get; set; } = default!;

    /// <summary>
    /// Vending machine's support number (Required).
    /// </summary>
    public System.String SupportNumber { get; set; } = default!;
}