// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public partial class StoreSecurityPasswords : AuditableEntityBase
{

    /// <summary>
    /// Passwords Primary Key (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Name { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text SecurityCamerasPassword { get; set; } = null!;

    /// <summary>
    /// StoreSecurityPasswords Store with this set of passwords ExactlyOne Stores
    /// </summary>
    public virtual Store Store { get; set; } = null!;
}