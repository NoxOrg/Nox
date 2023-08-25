// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record EmployeePhoneNumberKeyDto(System.Int64 keyId);

/// <summary>
/// Employee phone numbers and related data.
/// </summary>
public partial class EmployeePhoneNumberDto
{

    /// <summary>
    /// The employee's phone number identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The employee's phone number type (Required).
    /// </summary>
    public System.String PhoneNumberType { get; set; } = default!;

    /// <summary>
    /// The employee's phone number (Required).
    /// </summary>
    public System.String PhoneNumber { get; set; } = default!;
}