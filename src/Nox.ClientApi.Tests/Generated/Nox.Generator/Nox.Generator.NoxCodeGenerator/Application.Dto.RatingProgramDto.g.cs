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

public record RatingProgramKeyDto(System.Guid keyStoreId, System.Int64 keyId);

/// <summary>
/// Rating program for store.
/// </summary>
public partial class RatingProgramDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        if (this.Name is not null)
            ValidateField("Name", () => ClientApi.Domain.RatingProgram.CreateName(this.Name.NonNullValue<System.String>()), result);

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
    ///  (Required).
    /// </summary>
    public System.Guid StoreId { get; set; } = default!;

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public System.String? Name { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}