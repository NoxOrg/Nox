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

public record PersonKeyDto(System.Guid keyId);

/// <summary>
/// Update Person
/// Person.
/// </summary>
public partial class PersonDto : PersonDtoBase
{

}

/// <summary>
/// Person.
/// </summary>
public abstract class PersonDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.FirstName is not null)
            CollectValidationExceptions("FirstName", () => PersonMetadata.CreateFirstName(this.FirstName.NonNullValue<System.String>()), result);
        else
            result.Add("FirstName", new [] { "FirstName is Required." });
    
        if (this.LastName is not null)
            CollectValidationExceptions("LastName", () => PersonMetadata.CreateLastName(this.LastName.NonNullValue<System.String>()), result);
        else
            result.Add("LastName", new [] { "LastName is Required." });
    
        CollectValidationExceptions("TenantId", () => PersonMetadata.CreateTenantId(this.TenantId), result);
    
        if (this.PrimaryEmailAddress is not null)
            CollectValidationExceptions("PrimaryEmailAddress", () => PersonMetadata.CreatePrimaryEmailAddress(this.PrimaryEmailAddress.NonNullValue<System.String>()), result);
        else
            result.Add("PrimaryEmailAddress", new [] { "PrimaryEmailAddress is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// The person unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The user's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// The customer's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Tenant user bellongs to     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Guid TenantId { get; set; } = default!;

    /// <summary>
    /// The user's primary email for MFA     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PrimaryEmailAddress { get; set; } = default!;

    /// <summary>
    /// Person user selected contacts ZeroOrOne UserContactSelections
    /// </summary>
    public virtual UserContactSelectionDto? UserContactSelection { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}