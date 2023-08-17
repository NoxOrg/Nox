// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// The employee's email (Required).
    /// </summary>
    public System.String Email { get; set; } = default!;
    /// <summary>
    /// The employee's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// The employee's first working day (Required).
    /// </summary>
    public System.DateTime FirstWorkingDay { get; set; } = default!;
    /// <summary>
    /// The employee's last working day (Optional).
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; } 
}