// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLordModel : LandLordModelBase
{

}

/// <summary>
/// Landlord related data
/// </summary>
public abstract class LandLordModelBase: EntityDtoBase
{

    /// <summary>
    /// Landlord unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Landlord name     
    /// </summary>
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Landlord's street address     
    /// </summary>
    public virtual StreetAddressModel? Address { get; set; }
}