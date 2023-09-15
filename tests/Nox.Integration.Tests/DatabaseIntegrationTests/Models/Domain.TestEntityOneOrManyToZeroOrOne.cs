// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOneOrManyToZeroOrOne:TestEntityOneOrManyToZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne created event.
/// </summary>
public record TestEntityOneOrManyToZeroOrOneCreated(TestEntityOneOrManyToZeroOrOne TestEntityOneOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne updated event.
/// </summary>
public record TestEntityOneOrManyToZeroOrOneUpdated(TestEntityOneOrManyToZeroOrOne TestEntityOneOrManyToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrOne deleted event.
/// </summary>
public record TestEntityOneOrManyToZeroOrOneDeleted(TestEntityOneOrManyToZeroOrOne TestEntityOneOrManyToZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOneOrManyToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOneOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToOneOrMany OneOrMany TestEntityZeroOrOneToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrMany { get; set; } = new();

    public virtual void CreateRefToTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrMany relatedTestEntityZeroOrOneToOneOrMany)
    {
        TestEntityZeroOrOneToOneOrMany.Add(relatedTestEntityZeroOrOneToOneOrMany);
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}