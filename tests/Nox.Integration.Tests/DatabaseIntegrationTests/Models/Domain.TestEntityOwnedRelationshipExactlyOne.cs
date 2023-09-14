// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipExactlyOne:TestEntityOwnedRelationshipExactlyOneBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipExactlyOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
     public virtual SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}