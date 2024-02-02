// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionModel : CommissionModelBase
{

}

/// <summary>
/// Exchange commission rate and amount
/// </summary>
public abstract class CommissionModelBase: EntityDtoBase
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