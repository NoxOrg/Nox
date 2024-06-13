// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLordModel : LandLordModelBase
{

}

/// <summary>
/// Landlord related data
/// </summary>
public abstract class LandLordModelBase: IEntityModel
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