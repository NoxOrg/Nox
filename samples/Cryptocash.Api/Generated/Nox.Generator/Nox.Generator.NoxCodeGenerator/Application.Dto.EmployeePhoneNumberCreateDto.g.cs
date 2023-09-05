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

    public Cryptocash.Domain.EmployeePhoneNumber ToEntity()
    {
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(PhoneNumberType);
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(PhoneNumber);
        return entity;
    }
}