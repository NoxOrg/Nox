// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// User.
/// </summary>
public partial class UserIamUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// The customer's email (Required).
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    
    public System.String Email { get; set; } = default!;
}