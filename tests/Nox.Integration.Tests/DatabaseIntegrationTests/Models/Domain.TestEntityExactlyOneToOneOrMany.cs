// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany created event.
/// </summary>
public record TestEntityExactlyOneToOneOrManyCreated(TestEntityExactlyOneToOneOrMany TestEntityExactlyOneToOneOrMany) : IDomainEvent;

/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany updated event.
/// </summary>
public record TestEntityExactlyOneToOneOrManyUpdated(TestEntityExactlyOneToOneOrMany TestEntityExactlyOneToOneOrMany) : IDomainEvent;

/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany deleted event.
/// </summary>
public record TestEntityExactlyOneToOneOrManyDeleted(TestEntityExactlyOneToOneOrMany TestEntityExactlyOneToOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityExactlyOneToOneOrMany : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityExactlyOneToOneOrMany Test entity relationship to TestEntityOneOrManyToExactlyOne ExactlyOne TestEntityOneOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityOneOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityOneOrManyToExactlyOneId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}