// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOneOrMany:TestEntityOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityOneOrMany created event.
/// </summary>
public record TestEntityOneOrManyCreated(TestEntityOneOrMany TestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrMany updated event.
/// </summary>
public record TestEntityOneOrManyUpdated(TestEntityOneOrMany TestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrMany deleted event.
/// </summary>
public record TestEntityOneOrManyDeleted(TestEntityOneOrMany TestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOneOrMany Test entity relationship to SecondTestEntityOneOrMany OneOrMany SecondTestEntityOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOneOrMany> SecondTestEntityOneOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}