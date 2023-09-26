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

public record CountryLocalNameKeyDto(System.Int64 keyId);

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => ClientApi.Domain.CountryLocalName.CreateName(this.Name), result);
        if (this.NativeName is not null)
            ValidateField("NativeName", () => ClientApi.Domain.CountryLocalName.CreateNativeName(this.NativeName.NonNullValue<System.String>()), result);

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
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public System.String? NativeName { get; set; }
}