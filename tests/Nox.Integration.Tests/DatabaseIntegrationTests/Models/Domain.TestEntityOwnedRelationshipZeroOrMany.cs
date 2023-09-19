// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipZeroOrMany:TestEntityOwnedRelationshipZeroOrManyBase
{

}
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany created event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrManyCreated(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany updated event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrManyUpdated(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrMany deleted event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrManyDeleted(TestEntityOwnedRelationshipZeroOrMany TestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

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