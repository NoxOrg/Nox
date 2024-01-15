// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderPartialUpdateDto : PaymentProviderPartialUpdateDtoBase
{

}

/// <summary>
/// Payment provider related data
/// </summary>
public partial class PaymentProviderPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Payment provider name
    /// </summary>
    public virtual System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// Payment provider account type
    /// </summary>
    public virtual System.String PaymentProviderType { get; set; } = default!;
}