// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The tenant workplace.
/// </summary>
public partial class TenantWorkplaceContact : AuditableEntityBase
{
    
    /// <summary>
    /// (Optional)
    /// </summary>
    public Text Id { get; set; } = null!;
    
    /// <summary>
    /// The country's common name (required).
    /// </summary>
    public Text Name { get; set; } = null!;
}
