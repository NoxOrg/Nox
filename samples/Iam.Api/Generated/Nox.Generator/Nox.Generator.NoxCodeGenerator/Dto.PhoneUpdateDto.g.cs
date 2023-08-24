// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// Verified Phone.
/// </summary>
public partial class PhoneUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; } 
    /// <summary>
    /// Country code (Optional).
    /// </summary>
    public System.String? CountryCode { get; set; } 
}