// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryBarCodeKeyDto();

/// <summary>
/// Bar code for country.
/// </summary>
public partial class CountryBarCodeDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("BarCodeName", () => ClientApi.Domain.CountryBarCode.CreateBarCodeName(this.BarCodeName), result);
        if (this.BarCodeNumber is not null)
            ValidateField("BarCodeNumber", () => ClientApi.Domain.CountryBarCode.CreateBarCodeNumber(this.BarCodeNumber.NonNullValue<System.Int32>()), result);

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
    /// Bar code name (Required).
    /// </summary>
    public System.String BarCodeName { get; set; } = default!;

    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public System.Int32? BarCodeNumber { get; set; }
}