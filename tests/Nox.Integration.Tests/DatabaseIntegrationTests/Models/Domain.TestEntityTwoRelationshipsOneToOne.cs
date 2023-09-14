// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsOneToOne:TestEntityTwoRelationshipsOneToOneBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityTwoRelationshipsOneToOne First relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual SecondTestEntityTwoRelationshipsOneToOne TestRelationshipOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityTwoRelationshipsOneToOne
    /// </summary>
    public Nox.Types.Text TestRelationshipOneId { get; set; } = null!;

    /// <summary>
    /// TestEntityTwoRelationshipsOneToOne Second relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual SecondTestEntityTwoRelationshipsOneToOne TestRelationshipTwo { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityTwoRelationshipsOneToOne
    /// </summary>
    public Nox.Types.Text TestRelationshipTwoId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}