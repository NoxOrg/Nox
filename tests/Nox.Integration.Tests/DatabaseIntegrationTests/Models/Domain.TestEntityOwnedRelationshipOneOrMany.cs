// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany created event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyCreated(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent;

/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyUpdated(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent;

/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyDeleted(TestEntityOwnedRelationshipOneOrMany TestEntityOwnedRelationshipOneOrMany) : IDomainEvent;

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
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}