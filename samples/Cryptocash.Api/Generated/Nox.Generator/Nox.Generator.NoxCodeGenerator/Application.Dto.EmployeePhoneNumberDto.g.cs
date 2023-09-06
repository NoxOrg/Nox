// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeePhoneNumberKeyDto(System.Int64 keyId);

/// <summary>
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberDto
{

    /// <summary>
    /// Employee's phone number identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    public System.String PhoneNumberType { get; set; } = default!;

    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    public System.String PhoneNumber { get; set; } = default!;
}