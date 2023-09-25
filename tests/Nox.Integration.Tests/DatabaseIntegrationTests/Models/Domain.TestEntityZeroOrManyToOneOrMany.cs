// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToOneOrMany:TestEntityZeroOrManyToOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany created event.
/// </summary>
public record TestEntityZeroOrManyToOneOrManyCreated(TestEntityZeroOrManyToOneOrMany TestEntityZeroOrManyToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany updated event.
/// </summary>
public record TestEntityZeroOrManyToOneOrManyUpdated(TestEntityZeroOrManyToOneOrMany TestEntityZeroOrManyToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToOneOrMany deleted event.
/// </summary>
public record TestEntityZeroOrManyToOneOrManyDeleted(TestEntityZeroOrManyToOneOrMany TestEntityZeroOrManyToOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToOneOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// TestEntityZeroOrManyToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrMany ZeroOrMany TestEntityOneOrManyToZeroOrManies
    /// </summary>
    public virtual List<TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrMany relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrMany.Add(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrMany relatedTestEntityOneOrManyToZeroOrMany)
    {
        TestEntityOneOrManyToZeroOrMany.Remove(relatedTestEntityOneOrManyToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToZeroOrMany()
    {
        TestEntityOneOrManyToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}