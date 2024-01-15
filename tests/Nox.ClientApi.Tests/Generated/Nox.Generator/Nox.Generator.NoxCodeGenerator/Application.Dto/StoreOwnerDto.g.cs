// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace ClientApi.Application.Dto;

public record StoreOwnerKeyDto(System.String keyId);

/// <summary>
/// Update StoreOwner
/// Store owners.
/// </summary>
public partial class StoreOwnerDto : StoreOwnerDtoBase
{

}

/// <summary>
/// Store owners.
/// </summary>
public abstract class StoreOwnerDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => StoreOwnerMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.TemporaryOwnerName is not null)
            CollectValidationExceptions("TemporaryOwnerName", () => StoreOwnerMetadata.CreateTemporaryOwnerName(this.TemporaryOwnerName.NonNullValue<System.String>()), result);
        else
            result.Add("TemporaryOwnerName", new [] { "TemporaryOwnerName is Required." });
    
        if (this.VatNumber is not null)
            CollectValidationExceptions("VatNumber", () => StoreOwnerMetadata.CreateVatNumber(this.VatNumber.NonNullValue<VatNumberDto>()), result);
        if (this.StreetAddress is not null)
            CollectValidationExceptions("StreetAddress", () => StoreOwnerMetadata.CreateStreetAddress(this.StreetAddress.NonNullValue<StreetAddressDto>()), result);
        if (this.LocalGreeting is not null)
            CollectValidationExceptions("LocalGreeting", () => StoreOwnerMetadata.CreateLocalGreeting(this.LocalGreeting.NonNullValue<TranslatedTextDto>()), result);
        if (this.Notes is not null)
            CollectValidationExceptions("Notes", () => StoreOwnerMetadata.CreateNotes(this.Notes.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Owner Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Temporary Owner Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TemporaryOwnerName { get; set; } = default!;

    /// <summary>
    /// Vat Number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Street Address     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public StreetAddressDto? StreetAddress { get; set; }

    /// <summary>
    /// Owner Greeting     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public TranslatedTextDto? LocalGreeting { get; set; }

    /// <summary>
    /// Notes     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Notes { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns OneOrMany Stores
    /// </summary>
    public virtual List<StoreDto> Stores { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}