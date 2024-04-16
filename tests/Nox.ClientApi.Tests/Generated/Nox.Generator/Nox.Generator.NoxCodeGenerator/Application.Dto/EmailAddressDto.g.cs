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

public record EmailAddressKeyDto();

/// <summary>
/// Update EmailAddress
/// Verified Email Address.
/// </summary>
public partial class EmailAddressDto : EmailAddressDtoBase
{

}

/// <summary>
/// Verified Email Address.
/// </summary>
public abstract class EmailAddressDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Email is not null)
            CollectValidationExceptions("Email", () => EmailAddressMetadata.CreateEmail(this.Email.NonNullValue<System.String>()), result);
        if (this.IsVerified is not null)
            CollectValidationExceptions("IsVerified", () => EmailAddressMetadata.CreateIsVerified(this.IsVerified.NonNullValue<System.Boolean>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Email     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Email { get; set; }

    /// <summary>
    /// Verified     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Boolean? IsVerified { get; set; }
}