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

public record EmployeePhoneNumberKeyDto(System.Int64 keyId);

/// <summary>
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("PhoneNumberType", () => Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(this.PhoneNumberType), result);
        ValidateField("PhoneNumber", () => Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(this.PhoneNumber), result);

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
    /// Employee's phone number identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    public System.String PhoneNumberType { get; set; } = default!;

    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    public System.String PhoneNumber { get; set; } = default!;
}