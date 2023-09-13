// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityZeroOrMany created event.
/// </summary>
public record TestEntityZeroOrManyCreated(TestEntityZeroOrMany TestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for TestEntityZeroOrMany updated event.
/// </summary>
public record TestEntityZeroOrManyUpdated(TestEntityZeroOrMany TestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for TestEntityZeroOrMany deleted event.
/// </summary>
public record TestEntityZeroOrManyDeleted(TestEntityZeroOrMany TestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrMany : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrMany Test entity relationship to SecondTestEntityZeroOrMany ZeroOrMany SecondTestEntityZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}