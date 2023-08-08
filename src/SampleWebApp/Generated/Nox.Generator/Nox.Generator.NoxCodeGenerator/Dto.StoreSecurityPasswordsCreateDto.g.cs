// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswordsCreateDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String SecurityCamerasPassword { get; set; } = default!;
}