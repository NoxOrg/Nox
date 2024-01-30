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
    
        if (this.UserName is not null)
            CollectValidationExceptions("UserName", () => PersonMetadata.CreateUserName(this.UserName.NonNullValue<System.String>()), result);
        if (this.FirstName is not null)
            CollectValidationExceptions("FirstName", () => PersonMetadata.CreateFirstName(this.FirstName.NonNullValue<System.String>()), result);
        else
            result.Add("FirstName", new [] { "FirstName is Required." });
    
        if (this.LastName is not null)
            CollectValidationExceptions("LastName", () => PersonMetadata.CreateLastName(this.LastName.NonNullValue<System.String>()), result);
        else
            result.Add("LastName", new [] { "LastName is Required." });
    
        CollectValidationExceptions("TenantId", () => PersonMetadata.CreateTenantId(this.TenantId), result);
    
        if (this.TenantBrandId is not null)
            CollectValidationExceptions("TenantBrandId", () => PersonMetadata.CreateTenantBrandId(this.TenantBrandId.NonNullValue<System.Guid>()), result);
        if (this.PrimaryEmailAddress is not null)
            CollectValidationExceptions("PrimaryEmailAddress", () => PersonMetadata.CreatePrimaryEmailAddress(this.PrimaryEmailAddress.NonNullValue<System.String>()), result);
        else
            result.Add("PrimaryEmailAddress", new [] { "PrimaryEmailAddress is Required." });
    
        if (this.SecondaryEmailAddress is not null)
            CollectValidationExceptions("SecondaryEmailAddress", () => PersonMetadata.CreateSecondaryEmailAddress(this.SecondaryEmailAddress.NonNullValue<System.String>()), result);
        if (this.PhoneNumber is not null)
            CollectValidationExceptions("PhoneNumber", () => PersonMetadata.CreatePhoneNumber(this.PhoneNumber.NonNullValue<System.String>()), result);
        if (this.PrefferedLanguage is not null)
            CollectValidationExceptions("PrefferedLanguage", () => PersonMetadata.CreatePrefferedLanguage(this.PrefferedLanguage.NonNullValue<System.String>()), result);
        CollectValidationExceptions("Status", () => PersonMetadata.CreateStatus(this.Status), result);
    
        CollectValidationExceptions("Type", () => PersonMetadata.CreateType(this.Type), result);
    
        if (this.UserProfileId is not null)
            CollectValidationExceptions("UserProfileId", () => PersonMetadata.CreateUserProfileId(this.UserProfileId.NonNullValue<System.Int64>()), result);
        CollectValidationExceptions("PreferredLoginMethod", () => PersonMetadata.CreatePreferredLoginMethod(this.PreferredLoginMethod), result);
    
        if (this.HCountryIsoCode is not null)
            CollectValidationExceptions("HCountryIsoCode", () => PersonMetadata.CreateHCountryIsoCode(this.HCountryIsoCode.NonNullValue<System.String>()), result);
        if (this.HAcceptedTerms is not null)
            CollectValidationExceptions("HAcceptedTerms", () => PersonMetadata.CreateHAcceptedTerms(this.HAcceptedTerms.NonNullValue<System.Boolean>()), result);
        if (this.HEnablePasswordLess is not null)
            CollectValidationExceptions("HEnablePasswordLess", () => PersonMetadata.CreateHEnablePasswordLess(this.HEnablePasswordLess.NonNullValue<System.Boolean>()), result);
        if (this.HPrimaryEmailAddressVerified is not null)
            CollectValidationExceptions("HPrimaryEmailAddressVerified", () => PersonMetadata.CreateHPrimaryEmailAddressVerified(this.HPrimaryEmailAddressVerified.NonNullValue<System.Boolean>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// The person unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The users's username     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? UserName { get; set; }

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
    public System.Int32 TenantId { get; set; } = default!;

    /// <summary>
    /// Tenant Brand user bellongs to     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Guid? TenantBrandId { get; set; }

    /// <summary>
    /// The user's primary email for MFA     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PrimaryEmailAddress { get; set; } = default!;

    /// <summary>
    /// The user's secondary email for MFA     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? SecondaryEmailAddress { get; set; }

    /// <summary>
    /// The user's phone number for MFA     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? PhoneNumber { get; set; }

    /// <summary>
    /// The user's preferred language     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? PrefferedLanguage { get; set; }

    /// <summary>
    /// The user status     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 Status { get; set; } = default!;
    public string StatusName { get; set; } = default!;

    /// <summary>
    /// The user type     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 Type { get; set; } = default!;

    /// <summary>
    /// The user profile id     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int64? UserProfileId { get; set; }

    /// <summary>
    /// The preferred method of login     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 PreferredLoginMethod { get; set; } = default!;
    public string PreferredLoginMethodName { get; set; } = default!;

    /// <summary>
    /// The user's country code     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? HCountryIsoCode { get; set; }

    /// <summary>
    /// The user accepted terms and condition     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Boolean? HAcceptedTerms { get; set; }

    /// <summary>
    /// PasswordLess     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Boolean? HEnablePasswordLess { get; set; }

    /// <summary>
    /// The user verified primary email address     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Boolean? HPrimaryEmailAddressVerified { get; set; }

    /// <summary>
    /// Person user selected contacts ZeroOrOne UserContactSelections
    /// </summary>
    public virtual UserContactSelectionDto? UserContactSelection { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}