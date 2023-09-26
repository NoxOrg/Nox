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

public record EmailAddressKeyDto();

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        if (this.Email is not null)
            ValidateField("Email", () => ClientApi.Domain.EmailAddress.CreateEmail(this.Email.NonNullValue<System.String>()), result);
        if (this.IsVerified is not null)
            ValidateField("IsVerified", () => ClientApi.Domain.EmailAddress.CreateIsVerified(this.IsVerified.NonNullValue<System.Boolean>()), result);

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
    /// Email (Optional).
    /// </summary>
    public System.String? Email { get; set; }

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }
}