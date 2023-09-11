// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// .
/// </summary>
public partial class TestEntityExactlyOneToZeroOrOne : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrOneToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrOneToExactlyOneId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}