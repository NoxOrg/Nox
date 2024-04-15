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

public record TenantContactKeyDto();

/// <summary>
/// Update TenantContact
/// Tenant Contact.
/// </summary>
public partial class TenantContactDto : TenantContactDtoBase
{

}

/// <summary>
/// Tenant Contact.
/// </summary>
public abstract class TenantContactDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => TenantContactMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Description is not null)
            CollectValidationExceptions("Description", () => TenantContactMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result);
        else
            result.Add("Description", new [] { "Description is Required." });
    
        if (this.Email is not null)
            CollectValidationExceptions("Email", () => TenantContactMetadata.CreateEmail(this.Email.NonNullValue<System.String>()), result);
        else
            result.Add("Email", new [] { "Email is Required." });
    
        if (this.Status is not null)
            CollectValidationExceptions("Status", () => TenantContactMetadata.CreateStatus(this.Status.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Teanant Brand Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Teanant Brand Description     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Description { get; set; } = default!;

    /// <summary>
    /// Teanant Brand Email     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Email { get; set; } = default!;

    /// <summary>
    /// Tenant Brand Status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? Status { get; set; }
    public string? StatusName { get; set; } = default!;
}