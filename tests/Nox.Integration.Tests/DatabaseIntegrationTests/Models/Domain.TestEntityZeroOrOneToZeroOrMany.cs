// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrOneToZeroOrMany:TestEntityZeroOrOneToZeroOrManyBase
{

}
/// <summary>
/// Record for TestEntityZeroOrOneToZeroOrMany created event.
/// </summary>
public record TestEntityZeroOrOneToZeroOrManyCreated(TestEntityZeroOrOneToZeroOrMany TestEntityZeroOrOneToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOneToZeroOrMany updated event.
/// </summary>
public record TestEntityZeroOrOneToZeroOrManyUpdated(TestEntityZeroOrOneToZeroOrMany TestEntityZeroOrOneToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOneToZeroOrMany deleted event.
/// </summary>
public record TestEntityZeroOrOneToZeroOrManyDeleted(TestEntityZeroOrOneToZeroOrMany TestEntityZeroOrOneToZeroOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToZeroOrOne ZeroOrOne TestEntityZeroOrManyToZeroOrOnes
    /// </summary>
    public virtual TestEntityZeroOrManyToZeroOrOne? TestEntityZeroOrManyToZeroOrOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityZeroOrManyToZeroOrOne
    /// </summary>
    public Nox.Types.Text? TestEntityZeroOrManyToZeroOrOneId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}