// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne created event.
/// </summary>
public record TestEntityOneOrManyToExactlyOneCreated(TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne updated event.
/// </summary>
public record TestEntityOneOrManyToExactlyOneUpdated(TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityOneOrManyToExactlyOne deleted event.
/// </summary>
public record TestEntityOneOrManyToExactlyOneDeleted(TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOneOrManyToExactlyOne : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// TestEntityOneOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToOneOrMany OneOrMany TestEntityExactlyOneToOneOrManies
    /// </summary>
    public virtual List<TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}