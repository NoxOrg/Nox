// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderModel : PaymentProviderModelBase
{

}

/// <summary>
/// Payment provider related data
/// </summary>
public abstract class PaymentProviderModelBase: EntityDtoBase
{

    /// <summary>
    /// Payment provider unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Payment provider name     
    /// </summary>
    public virtual System.String? PaymentProviderName { get; set; }

    /// <summary>
    /// Payment provider account type     
    /// </summary>
    public virtual System.String? PaymentProviderType { get; set; }
}