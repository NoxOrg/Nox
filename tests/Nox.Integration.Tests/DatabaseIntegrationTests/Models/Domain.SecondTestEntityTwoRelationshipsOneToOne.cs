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
public partial class SecondTestEntityTwoRelationshipsOneToOne : EntityBase, IEntityConcurrent
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
    /// SecondTestEntityTwoRelationshipsOneToOne First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToOne? TestRelationshipOneOnOtherSide { get; set; } = null!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToOne? TestRelationshipTwoOnOtherSide { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}