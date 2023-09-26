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

public record BankNoteKeyDto(System.Int64 keyId);

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("CashNote", () => Cryptocash.Domain.BankNote.CreateCashNote(this.CashNote), result);
        ValidateField("Value", () => Cryptocash.Domain.BankNote.CreateValue(this.Value), result);

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
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    public System.String CashNote { get; set; } = default!;

    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    public MoneyDto Value { get; set; } = default!;
}