// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberCreateDto : IEntityCreateDto <EmployeePhoneNumber>
{    
    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    [Required(ErrorMessage = "PhoneNumberType is required")]
    
    public System.String PhoneNumberType { get; set; } = default!;    
    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    [Required(ErrorMessage = "PhoneNumber is required")]
    
    public System.String PhoneNumber { get; set; } = default!;

    public Cryptocash.Domain.EmployeePhoneNumber ToEntity()
    {
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(PhoneNumberType);
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(PhoneNumber);
        return entity;
    }
}