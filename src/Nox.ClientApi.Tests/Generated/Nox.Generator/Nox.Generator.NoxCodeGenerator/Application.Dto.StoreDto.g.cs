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

public record StoreKeyDto(System.Guid keyId);

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => ClientApi.Domain.Store.CreateName(this.Name), result);
        ValidateField("Address", () => ClientApi.Domain.Store.CreateAddress(this.Address), result);
        ValidateField("Location", () => ClientApi.Domain.Store.CreateLocation(this.Location), result);
        if (this.OpeningDay is not null)
            ValidateField("OpeningDay", () => ClientApi.Domain.Store.CreateOpeningDay(this.OpeningDay.NonNullValue<System.DateTimeOffset>()), result);

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
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Street Address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Location (Required).
    /// </summary>
    public LatLongDto Location { get; set; } = default!;

    /// <summary>
    /// Opening day (Optional).
    /// </summary>
    public System.DateTimeOffset? OpeningDay { get; set; }

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? OwnershipId { get; set; } = default!;
    public virtual StoreOwnerDto? Ownership { get; set; } = null!;

    /// <summary>
    /// Store License that this store uses ZeroOrOne StoreLicenses
    /// </summary>
    public virtual StoreLicenseDto? License { get; set; } = null!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressDto? VerifiedEmails { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}