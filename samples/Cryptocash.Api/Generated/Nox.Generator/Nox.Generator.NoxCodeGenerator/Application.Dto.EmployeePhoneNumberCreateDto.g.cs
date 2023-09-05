// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberCreateDto : EmployeePhoneNumberUpdateDto
{

    public EmployeePhoneNumber ToEntity()
    {
        var entity = new EmployeePhoneNumber();
        entity.PhoneNumberType = EmployeePhoneNumber.CreatePhoneNumberType(PhoneNumberType);
        entity.PhoneNumber = EmployeePhoneNumber.CreatePhoneNumber(PhoneNumber);
        return entity;
    }
}