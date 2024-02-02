// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingModel : BookingModelBase
{

}

/// <summary>
/// Exchange booking and related data
/// </summary>
public abstract class BookingModelBase: EntityDtoBase
{

    /// <summary>
    /// Booking unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Booking's amount exchanged from     
    /// </summary>
    public virtual MoneyModel? AmountFrom { get; set; }

    /// <summary>
    /// Booking's amount exchanged to     
    /// </summary>
    public virtual MoneyModel? AmountTo { get; set; }

    /// <summary>
    /// Booking's requested pick up date     
    /// </summary>
    public virtual DateTimeRangeModel? RequestedPickUpDate { get; set; }

    /// <summary>
    /// Booking's actual pick up date     
    /// </summary>
    public virtual DateTimeRangeModel? PickedUpDateTime { get; set; }

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
    public virtual VatNumberModel? VatNumber { get; set; }
}