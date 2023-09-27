// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOneOrManyToZeroOrMany:TestEntityOneOrManyToZeroOrManyBase
{

}
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany created event.
/// </summary>
public record TestEntityOneOrManyToZeroOrManyCreated(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany updated event.
/// </summary>
public record TestEntityOneOrManyToZeroOrManyUpdated(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrManyToZeroOrMany deleted event.
/// </summary>
public record TestEntityOneOrManyToZeroOrManyDeleted(TestEntityOneOrManyToZeroOrMany TestEntityOneOrManyToZeroOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityOneOrManyToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOneOrManyToZeroOrMany Test entity relationship to TestEntityZeroOrManyToOneOrMany OneOrMany TestEntityZeroOrManyToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrMany relatedTestEntityZeroOrManyToOneOrMany)
    {
        TestEntityZeroOrManyToOneOrMany.Add(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void DeleteRefToTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrMany relatedTestEntityZeroOrManyToOneOrMany)
    {
        if(TestEntityZeroOrManyToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityZeroOrManyToOneOrMany.Remove(relatedTestEntityZeroOrManyToOneOrMany);
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyToOneOrMany()
    {
        if(TestEntityZeroOrManyToOneOrMany.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestEntityZeroOrManyToOneOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}