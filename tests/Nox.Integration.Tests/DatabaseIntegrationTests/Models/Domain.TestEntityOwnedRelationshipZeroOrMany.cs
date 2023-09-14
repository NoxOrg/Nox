// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipZeroOrMany:TestEntityOwnedRelationshipZeroOrManyBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOwnedRelationshipZeroOrMany Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrMany ZeroOrMany SecondTestEntityOwnedRelationshipZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipZeroOrMany> SecondTestEntityOwnedRelationshipZeroOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}