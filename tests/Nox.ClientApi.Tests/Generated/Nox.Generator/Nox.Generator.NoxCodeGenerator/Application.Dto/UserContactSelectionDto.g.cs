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

public record UserContactSelectionKeyDto();

/// <summary>
/// Update UserContactSelection
/// User Contacts.
/// </summary>
public partial class UserContactSelectionDto : UserContactSelectionDtoBase
{

}

/// <summary>
/// User Contacts.
/// </summary>
public abstract class UserContactSelectionDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        CollectValidationExceptions("ContactId", () => UserContactSelectionMetadata.CreateContactId(this.ContactId), result);
    
        CollectValidationExceptions("AccountId", () => UserContactSelectionMetadata.CreateAccountId(this.AccountId), result);
    
        CollectValidationExceptions("SelectedDate", () => UserContactSelectionMetadata.CreateSelectedDate(this.SelectedDate), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Contact Id that user switched to     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Guid ContactId { get; set; } = default!;

    /// <summary>
    /// Account Id that user switched to     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Guid AccountId { get; set; } = default!;

    /// <summary>
    /// selected date     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTimeOffset SelectedDate { get; set; } = default!;
}