// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne created event.
/// </summary>
public record TestEntityOwnedRelationshipExactlyOneCreated(TestEntityOwnedRelationshipExactlyOne TestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne updated event.
/// </summary>
public record TestEntityOwnedRelationshipExactlyOneUpdated(TestEntityOwnedRelationshipExactlyOne TestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne deleted event.
/// </summary>
public record TestEntityOwnedRelationshipExactlyOneDeleted(TestEntityOwnedRelationshipExactlyOne TestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipExactlyOne : AuditableEntityBase, IEntityConcurrent
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