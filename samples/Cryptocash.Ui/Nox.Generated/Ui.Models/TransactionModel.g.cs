// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionModel : TransactionModelBase
{

}

/// <summary>
/// Customer transaction log and related data
/// </summary>
public abstract class TransactionModelBase: EntityDtoBase
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