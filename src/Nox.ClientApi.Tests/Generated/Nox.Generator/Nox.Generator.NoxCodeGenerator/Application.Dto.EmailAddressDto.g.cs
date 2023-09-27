
// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record EmailAddressKeyDto();

public partial class EmailAddressDto : EmailAddressDtoBase
{

}

/// <summary>
/// Verified Email Address.
/// </summary>
public abstract class EmailAddressDtoBase : EntityDtoBase, IEntityDto<EmailAddress>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Email is not null)
            TryGetValidationExceptions("Email", () => ClientApi.Domain.EmailAddressMetadata.CreateEmail(this.Email.NonNullValue<System.String>()), result);
        if (this.IsVerified is not null)
            TryGetValidationExceptions("IsVerified", () => ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(this.IsVerified.NonNullValue<System.Boolean>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Email (Optional).
    /// </summary>
    public System.String? Email { get; set; }

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }
}