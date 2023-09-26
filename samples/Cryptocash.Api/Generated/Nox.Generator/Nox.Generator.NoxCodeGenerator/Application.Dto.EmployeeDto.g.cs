// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeeKeyDto(System.Int64 keyId);

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("FirstName", () => Cryptocash.Domain.Employee.CreateFirstName(this.FirstName), result);
        ValidateField("LastName", () => Cryptocash.Domain.Employee.CreateLastName(this.LastName), result);
        ValidateField("EmailAddress", () => Cryptocash.Domain.Employee.CreateEmailAddress(this.EmailAddress), result);
        ValidateField("Address", () => Cryptocash.Domain.Employee.CreateAddress(this.Address), result);
        ValidateField("FirstWorkingDay", () => Cryptocash.Domain.Employee.CreateFirstWorkingDay(this.FirstWorkingDay), result);
        if (this.LastWorkingDay is not null)
            ValidateField("LastWorkingDay", () => Cryptocash.Domain.Employee.CreateLastWorkingDay(this.LastWorkingDay.NonNullValue<System.DateTime>()), result);

        return result;
    }

    private void ValidateField<T>(string fieldName, Func<T> action, Dictionary<string, IEnumerable<string>> result)
    {
        try
        {
            action();
        }
        catch (TypeValidationException ex)
        {
            result.Add(fieldName, ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (NullReferenceException)
        {
            result.Add(fieldName, new List<string> { $"{fieldName} is Required." });
        }
    }
    #endregion

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
    public System.Int64? EmployeeReviewingCashStockOrderId { get; set; } = default!;
    public virtual CashStockOrderDto? EmployeeReviewingCashStockOrder { get; set; } = null!;

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberDto> EmployeeContactPhoneNumbers { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}