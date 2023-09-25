// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToExactlyOne:TestEntityZeroOrManyToExactlyOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne created event.
/// </summary>
public record TestEntityZeroOrManyToExactlyOneCreated(TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne updated event.
/// </summary>
public record TestEntityZeroOrManyToExactlyOneUpdated(TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrManyToExactlyOne deleted event.
/// </summary>
public record TestEntityZeroOrManyToExactlyOneDeleted(TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToExactlyOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrMany ZeroOrMany TestEntityExactlyOneToZeroOrManies
    /// </summary>
    public virtual List<TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrMany { get; private set; } = new();

    public virtual void CreateRefToTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrMany relatedTestEntityExactlyOneToZeroOrMany)
    {
        TestEntityExactlyOneToZeroOrMany.Add(relatedTestEntityExactlyOneToZeroOrMany);
    }

    public virtual void DeleteRefToTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrMany relatedTestEntityExactlyOneToZeroOrMany)
    {
        TestEntityExactlyOneToZeroOrMany.Remove(relatedTestEntityExactlyOneToZeroOrMany);
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToZeroOrMany()
    {
        TestEntityExactlyOneToZeroOrMany.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}