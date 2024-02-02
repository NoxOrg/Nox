// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeModel : EmployeeModelBase
{

}

/// <summary>
/// Employee definition and related data
/// </summary>
public abstract class EmployeeModelBase: EntityDtoBase
{

    /// <summary>
    /// Employee's unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Employee's first name     
    /// </summary>
    public virtual System.String? FirstName { get; set; }

    /// <summary>
    /// Employee's last name     
    /// </summary>
    public virtual System.String? LastName { get; set; }

    /// <summary>
    /// Employee's email address     
    /// </summary>
    public virtual System.String? EmailAddress { get; set; }

    /// <summary>
    /// Employee's street address     
    /// </summary>
    public virtual StreetAddressModel? Address { get; set; }

    /// <summary>
    /// Employee's first working day     
    /// </summary>
    public virtual System.DateTime? FirstWorkingDay { get; set; }

    /// <summary>
    /// Employee's last working day     
    /// </summary>
    public virtual System.DateTime? LastWorkingDay { get; set; }
}