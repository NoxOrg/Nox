// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionModel : TransactionModelBase
{

}

/// <summary>
/// Customer transaction log and related data
/// </summary>
public abstract class TransactionModelBase: IEntityModel
{

    /// <summary>
    /// Customer transaction unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Transaction type     
    /// </summary>
    public virtual System.String? TransactionType { get; set; }

    /// <summary>
    /// Transaction processed datetime     
    /// </summary>
    public virtual System.DateTimeOffset? ProcessedOnDateTime { get; set; }

    /// <summary>
    /// Transaction amount     
    /// </summary>
    public virtual MoneyModel? Amount { get; set; }

    /// <summary>
    /// Transaction external reference     
    /// </summary>
    public virtual System.String? Reference { get; set; }
}