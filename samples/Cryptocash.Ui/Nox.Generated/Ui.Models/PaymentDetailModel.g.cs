// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailModel : PaymentDetailModelBase
{

}

/// <summary>
/// Customer payment account related data
/// </summary>
public abstract class PaymentDetailModelBase: EntityDtoBase
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
}