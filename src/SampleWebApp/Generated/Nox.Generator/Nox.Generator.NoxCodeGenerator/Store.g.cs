// Generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Stores.
/// </summary>
public partial class Store : AuditableEntityBase
{
    
    /// <summary>
    /// Store Primary Key (optional).
    /// </summary>
    public Text Id { get; set; } = null!;
    
    /// <summary>
    /// Store Name (required).
    /// </summary>
    public Text Name { get; set; } = null!;
    
    /// <summary>
    /// Physical Money in the Physical Store (required).
    /// </summary>
    public Money PhysicalMoney { get; set; } = null!;
}
