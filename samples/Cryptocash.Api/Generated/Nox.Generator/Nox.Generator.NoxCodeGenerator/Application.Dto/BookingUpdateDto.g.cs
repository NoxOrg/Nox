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
public partial class BookingUpdateDto : BookingUpdateDtoBase
{

}

/// <summary>
/// Exchange booking and related data
/// </summary>
public partial class BookingUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Booking>
{
    /// <summary>
    /// Booking's amount exchanged from     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public virtual MoneyDto AmountFrom { get; set; } = default!;
    /// <summary>
    /// Booking's amount exchanged to     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public virtual MoneyDto AmountTo { get; set; } = default!;
    /// <summary>
    /// Booking's requested pick up date     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public virtual DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;
    /// <summary>
    /// Booking's actual pick up date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// Booking's expiry date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTimeOffset? ExpiryDateTime { get; set; }
    /// <summary>
    /// Booking's cancelled date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// Booking's related vat number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual VatNumberDto? VatNumber { get; set; }
}