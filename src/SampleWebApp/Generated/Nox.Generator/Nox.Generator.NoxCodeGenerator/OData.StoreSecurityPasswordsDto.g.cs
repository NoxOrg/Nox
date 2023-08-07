// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswordsDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public String Name { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    public String SecurityCamerasPassword { get; set; } = default!;
}