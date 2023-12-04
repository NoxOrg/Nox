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
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailPartialUpdateDto : PaymentDetailPartialUpdateDtoBase
{

}

/// <summary>
/// Customer payment account related data
/// </summary>
public partial class PaymentDetailPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.PaymentDetail>
{
    /// <summary>
    /// Payment account name
    /// </summary>
    public virtual System.String PaymentAccountName { get; set; } = default!;
    /// <summary>
    /// Payment account reference number
    /// </summary>
    public virtual System.String PaymentAccountNumber { get; set; } = default!;
    /// <summary>
    /// Payment account sort code
    /// </summary>
    public virtual System.String? PaymentAccountSortCode { get; set; }
}