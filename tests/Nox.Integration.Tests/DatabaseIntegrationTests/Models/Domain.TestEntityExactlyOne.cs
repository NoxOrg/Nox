// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityExactlyOne created event.
/// </summary>
public record TestEntityExactlyOneCreated(TestEntityExactlyOne TestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityExactlyOne updated event.
/// </summary>
public record TestEntityExactlyOneUpdated(TestEntityExactlyOne TestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityExactlyOne deleted event.
/// </summary>
public record TestEntityExactlyOneDeleted(TestEntityExactlyOne TestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityExactlyOne : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityExactlyOne Test entity relationship to SecondTestEntityExactlyOneRelationship ExactlyOne SecondTestEntityExactlyOnes
    /// </summary>
    public virtual SecondTestEntityExactlyOne SecondTestEntityExactlyOneRelationship { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityExactlyOne
    /// </summary>
    public Nox.Types.Text SecondTestEntityExactlyOneRelationshipId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}