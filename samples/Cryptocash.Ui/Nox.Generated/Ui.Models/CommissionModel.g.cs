// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionModel : CommissionModelBase
{

}

/// <summary>
/// Exchange commission rate and amount
/// </summary>
public abstract class CommissionModelBase: IEntityModel
{

    /// <summary>
    /// Commission unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Commission rate     
    /// </summary>
    public virtual System.Single? Rate { get; set; }

    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    public virtual System.DateTimeOffset? EffectiveAt { get; set; }
}