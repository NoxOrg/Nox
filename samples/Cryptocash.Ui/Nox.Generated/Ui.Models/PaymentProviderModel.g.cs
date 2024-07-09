// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderModel : PaymentProviderModelBase
{

}

/// <summary>
/// Payment provider related data
/// </summary>
public abstract class PaymentProviderModelBase: IEntityModel
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

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }

}