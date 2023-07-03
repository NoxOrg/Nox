// Generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The identifier (primary key) for a Store.
/// </summary>
public class StoreId : ValueObject<Text,StoreId> {}

/// <summary>
/// Stores.
/// </summary>
public partial class Store : AuditableEntityBase
{
    
    /// <summary>
    /// Store Primary Key (optional).
    /// </summary>
    public StoreId Id { get; set; } = null!;
    
    /// <summary>
    /// Store Name (required).
    /// </summary>
    public Text Name { get; set; } = null!;
}
