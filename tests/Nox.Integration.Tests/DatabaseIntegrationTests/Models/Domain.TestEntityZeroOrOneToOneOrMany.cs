// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrOneToOneOrMany:TestEntityZeroOrOneToOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityZeroOrOneToOneOrMany created event.
/// </summary>
public record TestEntityZeroOrOneToOneOrManyCreated(TestEntityZeroOrOneToOneOrMany TestEntityZeroOrOneToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOneToOneOrMany updated event.
/// </summary>
public record TestEntityZeroOrOneToOneOrManyUpdated(TestEntityZeroOrOneToOneOrMany TestEntityZeroOrOneToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOneToOneOrMany deleted event.
/// </summary>
public record TestEntityZeroOrOneToOneOrManyDeleted(TestEntityZeroOrOneToOneOrMany TestEntityZeroOrOneToOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrOneToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrOne ZeroOrOne TestEntityOneOrManyToZeroOrOnes
    /// </summary>
    public virtual TestEntityOneOrManyToZeroOrOne? TestEntityOneOrManyToZeroOrOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityOneOrManyToZeroOrOne
    /// </summary>
    public Nox.Types.Text? TestEntityOneOrManyToZeroOrOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOne relatedTestEntityOneOrManyToZeroOrOne)
    {
        TestEntityOneOrManyToZeroOrOne = relatedTestEntityOneOrManyToZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOne relatedTestEntityOneOrManyToZeroOrOne)
    {
        TestEntityOneOrManyToZeroOrOne = null;
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToZeroOrOne()
    {
        TestEntityOneOrManyToZeroOrOneId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}