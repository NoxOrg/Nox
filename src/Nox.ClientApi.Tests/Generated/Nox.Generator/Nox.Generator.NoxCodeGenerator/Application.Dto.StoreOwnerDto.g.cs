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

public record StoreOwnerKeyDto(System.String keyId);

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => ClientApi.Domain.StoreOwner.CreateName(this.Name), result);
        ValidateField("TemporaryOwnerName", () => ClientApi.Domain.StoreOwner.CreateTemporaryOwnerName(this.TemporaryOwnerName), result);
        if (this.VatNumber is not null)
            ValidateField("VatNumber", () => ClientApi.Domain.StoreOwner.CreateVatNumber(this.VatNumber.NonNullValue<VatNumberDto>()), result);
        if (this.StreetAddress is not null)
            ValidateField("StreetAddress", () => ClientApi.Domain.StoreOwner.CreateStreetAddress(this.StreetAddress.NonNullValue<StreetAddressDto>()), result);
        if (this.LocalGreeting is not null)
            ValidateField("LocalGreeting", () => ClientApi.Domain.StoreOwner.CreateLocalGreeting(this.LocalGreeting.NonNullValue<TranslatedTextDto>()), result);
        if (this.Notes is not null)
            ValidateField("Notes", () => ClientApi.Domain.StoreOwner.CreateNotes(this.Notes.NonNullValue<System.String>()), result);

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
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Temporary Owner Name (Required).
    /// </summary>
    public System.String TemporaryOwnerName { get; set; } = default!;

    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddress { get; set; }

    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public TranslatedTextDto? LocalGreeting { get; set; }

    /// <summary>
    /// Notes (Optional).
    /// </summary>
    public System.String? Notes { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<StoreDto> Stores { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}