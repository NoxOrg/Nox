// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeePhoneNumberKeyDto(System.Int64 keyId);

/// <summary>
/// Employee phone numbers and related data.
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

    public EmployeePhoneNumber ToEntity()
    {
        var entity = new EmployeePhoneNumber();
        entity.Id = EmployeePhoneNumber.CreateId(Id);
        entity.PhoneNumberType = EmployeePhoneNumber.CreatePhoneNumberType(PhoneNumberType);
        entity.PhoneNumber = EmployeePhoneNumber.CreatePhoneNumber(PhoneNumber);
        return entity;
    }

}