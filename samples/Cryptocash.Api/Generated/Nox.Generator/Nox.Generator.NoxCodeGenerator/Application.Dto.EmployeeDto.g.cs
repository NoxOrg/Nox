// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeeKeyDto(System.Int64 keyId);

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeDto
{

    /// <summary>
    /// Employee's unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Employee's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Employee's email address (Required).
    /// </summary>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Employee's street address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Employee's first working day (Required).
    /// </summary>
    public System.DateTime FirstWorkingDay { get; set; } = default!;

    /// <summary>
    /// Employee's last working day (Optional).
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee reviewing ExactlyOne CashStockOrders
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 EmployeeReviewingCashStockOrderId { get; set; } = default!;
    public virtual CashStockOrderDto EmployeeReviewingCashStockOrder { get; set; } = null!;

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    [JsonProperty("@odata.etag")]
    public System.Guid Etag { get; set; }
}