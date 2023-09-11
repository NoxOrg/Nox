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
public partial class TestEntityOwnedRelationshipOneOrMany : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOwnedRelationshipOneOrMany Test entity relationship to SecondTestEntityOwnedRelationshipOneOrMany OneOrMany SecondTestEntityOwnedRelationshipOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipOneOrMany> SecondTestEntityOwnedRelationshipOneOrManies { get; set; } = new();

    public List<SecondTestEntityOwnedRelationshipOneOrMany> SecondTestEntityOwnedRelationshipOneOrMany => SecondTestEntityOwnedRelationshipOneOrManies;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}