// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionPartialUpdateDto : TransactionPartialUpdateDtoBase
{

}

/// <summary>
/// Customer transaction log and related data
/// </summary>
public partial class TransactionPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Transaction>
{
    /// <summary>
    /// Transaction type
    /// </summary>
    public virtual System.String TransactionType { get; set; } = default!;
    /// <summary>
    /// Transaction processed datetime
    /// </summary>
    public virtual System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;
    /// <summary>
    /// Transaction amount
    /// </summary>
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Transaction external reference
    /// </summary>
    public virtual System.String Reference { get; set; } = default!;
}