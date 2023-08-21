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

public record CustomerKeyDto(System.Int64 keyId);

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerDto 
{

    /// <summary>
    /// The Customer unique identifier (Required).
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// The customer's email (Required).
    /// </summary>
    public System.String Email { get; set; } = default!;

    /// <summary>
    /// The customer's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// The customer's mobile number (Optional).
    /// </summary>
    public System.String? MobileNumber { get; set; } 
    public bool? Deleted { get; set; }
}