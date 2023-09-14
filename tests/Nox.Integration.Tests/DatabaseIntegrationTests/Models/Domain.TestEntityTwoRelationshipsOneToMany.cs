// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsOneToMany:TestEntityTwoRelationshipsOneToManyBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityTwoRelationshipsOneToMany First relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipOne { get; set; } = new();

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany Second relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipTwo { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}