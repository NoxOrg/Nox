// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// User Contacts.
/// </summary>
public partial class UserContactSelectionUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// what is the contact id? (Required).
    /// </summary>
    [Required(ErrorMessage = "ContactId is required")]
    
    public System.Guid ContactId { get; set; } = default!;
    /// <summary>
    /// account id (Required).
    /// </summary>
    [Required(ErrorMessage = "AccountId is required")]
    
    public System.Guid AccountId { get; set; } = default!;
    /// <summary>
    /// selected date (Required).
    /// </summary>
    [Required(ErrorMessage = "SelectedDate is required")]
    
    public System.DateTimeOffset SelectedDate { get; set; } = default!;
}