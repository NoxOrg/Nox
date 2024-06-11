// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailModel : PaymentDetailModelBase
{

}

/// <summary>
/// Customer payment account related data
/// </summary>
public abstract class PaymentDetailModelBase: IEntityModel
{

    /// <summary>
    /// Customer payment account unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Payment account name     
    /// </summary>
    public virtual System.String? PaymentAccountName { get; set; }

    /// <summary>
    /// Payment account reference number     
    /// </summary>
    public virtual System.String? PaymentAccountNumber { get; set; }

    /// <summary>
    /// Payment account sort code     
    /// </summary>
    public virtual System.String? PaymentAccountSortCode { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }

}