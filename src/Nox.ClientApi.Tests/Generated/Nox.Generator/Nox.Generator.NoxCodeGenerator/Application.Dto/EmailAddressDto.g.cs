// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

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
public abstract class EmailAddressDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.EmailAddress>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Email is not null)
            ExecuteActionAndCollectValidationExceptions("Email", () => DomainNamespace.EmailAddressMetadata.CreateEmail(this.Email.NonNullValue<System.String>()), result);
        if (this.IsVerified is not null)
            ExecuteActionAndCollectValidationExceptions("IsVerified", () => DomainNamespace.EmailAddressMetadata.CreateIsVerified(this.IsVerified.NonNullValue<System.Boolean>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Email 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Email { get; set; }

    /// <summary>
    /// Verified 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Boolean? IsVerified { get; set; }
}