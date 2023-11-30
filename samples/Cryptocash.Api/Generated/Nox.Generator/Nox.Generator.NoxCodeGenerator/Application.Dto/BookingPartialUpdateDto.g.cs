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
/// Exchange booking and related data.
/// </summary>
public partial class BookingPartialUpdateDto : BookingPartialUpdateDtoBase
{

}

/// <summary>
/// Exchange booking and related data
/// </summary>
public partial class BookingPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Booking>
{
    /// <summary>
    /// Booking's amount exchanged from
    /// </summary>
    public virtual MoneyDto AmountFrom { get; set; } = default!;
    /// <summary>
    /// Booking's amount exchanged to
    /// </summary>
    public virtual MoneyDto AmountTo { get; set; } = default!;
    /// <summary>
    /// Booking's requested pick up date
    /// </summary>
    public virtual DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;
    /// <summary>
    /// Booking's actual pick up date
    /// </summary>
    public virtual DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// Booking's expiry date
    /// </summary>
    public virtual System.DateTimeOffset? ExpiryDateTime { get; set; }
    /// <summary>
    /// Booking's cancelled date
    /// </summary>
    public virtual System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// Booking's related vat number
    /// </summary>
    public virtual VatNumberDto? VatNumber { get; set; }
}