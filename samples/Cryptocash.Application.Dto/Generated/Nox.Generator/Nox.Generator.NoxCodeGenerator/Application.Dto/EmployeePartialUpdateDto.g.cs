// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeePartialUpdateDto : EmployeePartialUpdateDtoBase
{

}

/// <summary>
/// Employee definition and related data
/// </summary>
public partial class EmployeePartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Employee's first name
    /// </summary>
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Employee's last name
    /// </summary>
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Employee's email address
    /// </summary>
    public virtual System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Employee's street address
    /// </summary>
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Employee's first working day
    /// </summary>
    public virtual System.DateTime FirstWorkingDay { get; set; } = default!;
    /// <summary>
    /// Employee's last working day
    /// </summary>
    public virtual System.DateTime? LastWorkingDay { get; set; }
}