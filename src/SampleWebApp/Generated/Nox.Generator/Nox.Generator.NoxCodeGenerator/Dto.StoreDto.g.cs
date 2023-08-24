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

public class StoreKeyDto
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;
}

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto : StoreKeyDto
{

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public MoneyDto PhysicalMoney { get; set; } = default!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswordsDto StoreSecurityPasswords { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}