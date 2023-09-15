// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrMany:TestEntityZeroOrManyBase
{

}
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
public abstract class TestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrMany Test entity relationship to SecondTestEntityZeroOrMany ZeroOrMany SecondTestEntityZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManyRelationship { get; set; } = new();

    public virtual void CreateRefToSecondTestEntityZeroOrManySecondTestEntityZeroOrManyRelationship(SecondTestEntityZeroOrMany relatedSecondTestEntityZeroOrMany)
    {
        SecondTestEntityZeroOrManyRelationship.Add(relatedSecondTestEntityZeroOrMany);
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}