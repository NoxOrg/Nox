// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// ApplicationIAM.
/// </summary>
public partial class ApplicationIAMUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
}