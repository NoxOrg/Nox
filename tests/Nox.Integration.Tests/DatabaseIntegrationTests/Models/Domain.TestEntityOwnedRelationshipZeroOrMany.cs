// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

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
public partial class TestEntityOwnedRelationshipZeroOrMany : AuditableEntityBase, IEntityConcurrent
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
    public virtual List<SecondTestEntityOwnedRelationshipZeroOrMany> SecondTestEntityOwnedRelationshipZeroOrManies { get; set; } = new();

    public List<SecondTestEntityOwnedRelationshipZeroOrMany> SecondTestEntityOwnedRelationshipZeroOrMany => SecondTestEntityOwnedRelationshipZeroOrManies;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}