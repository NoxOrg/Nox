// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

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
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public Nox.Types.Money PhysicalMoney { get; set; } = null!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswords StoreSecurityPasswords { get; set; } = null!;

    public StoreSecurityPasswords PasswordsRel => StoreSecurityPasswords;

    /// <summary>
    /// Store Store owner relationship ZeroOrOne StoreOwners
    /// </summary>
    public virtual StoreOwner? StoreOwner { get; set; } = null!;

    public StoreOwner? OwnerRel => StoreOwner;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity StoreOwner
    /// </summary>
    public Nox.Types.Text? StoreOwnerId { get; set; } = null!;
}