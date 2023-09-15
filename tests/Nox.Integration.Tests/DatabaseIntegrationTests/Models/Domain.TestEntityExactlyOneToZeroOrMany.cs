// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityExactlyOneToZeroOrMany:TestEntityExactlyOneToZeroOrManyBase
{

}
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany created event.
/// </summary>
public record TestEntityExactlyOneToZeroOrManyCreated(TestEntityExactlyOneToZeroOrMany TestEntityExactlyOneToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany updated event.
/// </summary>
public record TestEntityExactlyOneToZeroOrManyUpdated(TestEntityExactlyOneToZeroOrMany TestEntityExactlyOneToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany deleted event.
/// </summary>
public record TestEntityExactlyOneToZeroOrManyDeleted(TestEntityExactlyOneToZeroOrMany TestEntityExactlyOneToZeroOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityExactlyOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToExactlyOne ExactlyOne TestEntityZeroOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrManyToExactlyOneId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}