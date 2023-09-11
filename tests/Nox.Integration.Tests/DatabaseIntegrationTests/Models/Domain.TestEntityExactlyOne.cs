// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityExactlyOne : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;

    /// <summary>
    /// TestEntityExactlyOne Test entity relationship to SecondTestEntityExactlyOneRelationship ExactlyOne SecondTestEntityExactlyOnes
    /// </summary>
    public virtual SecondTestEntityExactlyOne SecondTestEntityExactlyOneRelationship { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityExactlyOne
    /// </summary>
    public Nox.Types.Text SecondTestEntityExactlyOneRelationshipId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}