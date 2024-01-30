// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// User Contacts.
/// </summary>
public partial class UserContactSelectionUpsertDto : UserContactSelectionUpsertDtoBase
{

}

/// <summary>
/// User Contacts
/// </summary>
public abstract class UserContactSelectionUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// Contact Id that user switched to     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "ContactId is required")]
    public virtual System.Guid? ContactId { get; set; }

    /// <summary>
    /// Account Id that user switched to     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "AccountId is required")]
    public virtual System.Guid? AccountId { get; set; }

    /// <summary>
    /// selected date     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "SelectedDate is required")]
    public virtual System.DateTimeOffset? SelectedDate { get; set; }
}