// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Stores.
/// </summary>
public partial class Store : AuditableEntityBase
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public Text Name { get; set; } = null!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public Money PhysicalMoney { get; set; } = null!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswords StoreSecurityPasswords { get; set; } = null!;
}