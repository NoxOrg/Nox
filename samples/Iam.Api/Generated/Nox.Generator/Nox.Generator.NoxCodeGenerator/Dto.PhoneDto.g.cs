// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using IamApi.Application.DataTransferObjects;
using IamApi.Domain;

namespace IamApi.Application.Dto;

public record PhoneKeyDto(System.String keyPhoneNumber);

/// <summary>
/// Verified Phone.
/// </summary>
public partial class PhoneDto
{

    /// <summary>
    /// Phone (Required).
    /// </summary>
    public System.String PhoneNumber { get; set; } = default!;

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }

    /// <summary>
    /// Country code (Optional).
    /// </summary>
    public System.String? CountryCode { get; set; }
}