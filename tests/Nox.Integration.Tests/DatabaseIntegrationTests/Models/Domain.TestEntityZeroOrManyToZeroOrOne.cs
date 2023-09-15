// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToZeroOrOne:TestEntityZeroOrManyToZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne created event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneCreated(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne updated event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneUpdated(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToZeroOrOne deleted event.
/// </summary>
public record TestEntityZeroOrManyToZeroOrOneDeleted(TestEntityZeroOrManyToZeroOrOne TestEntityZeroOrManyToZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}