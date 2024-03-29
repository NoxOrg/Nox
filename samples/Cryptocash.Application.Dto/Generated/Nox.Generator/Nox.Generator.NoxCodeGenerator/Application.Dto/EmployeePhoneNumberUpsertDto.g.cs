﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberUpsertDto : EmployeePhoneNumberUpsertDtoBase
{

}

/// <summary>
/// Employee phone number and related data
/// </summary>
public abstract class EmployeePhoneNumberUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// Employee's phone number identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Employee's phone number type     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PhoneNumberType is required")]
    public virtual System.String? PhoneNumberType { get; set; }

    /// <summary>
    /// Employee's phone number     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PhoneNumber is required")]
    public virtual System.String? PhoneNumber { get; set; }
}