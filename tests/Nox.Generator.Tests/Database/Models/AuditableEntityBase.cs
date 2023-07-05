// Generated

#nullable enable

using System;

namespace TestDatabaseWebApp.Domain;

public partial class AuditableEntityBase
{
    /// <summary>
    /// The date and time when this entity was first created (in Coordinated Universal Time).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// The user that created the entity.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The date and time when this entity was last updated (in Coordinated Universal Time).
    /// </summary>
    public DateTime? UpdatedAtUtc { get; set; }

    /// <summary>
    /// The user that last updated the entity.
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// The date and time when this entity was deleted (in Coordinated Universal Time).
    /// </summary>
    public DateTime? DeletedAtUtc { get; set; }

    /// <summary>
    /// The user that deleted the entity.
    /// </summary>
    public string? DeletedBy { get; set; }
}
