// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrOne:TestEntityZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrOne created event.
/// </summary>
public record TestEntityZeroOrOneCreated(TestEntityZeroOrOne TestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOne updated event.
/// </summary>
public record TestEntityZeroOrOneUpdated(TestEntityZeroOrOne TestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOne deleted event.
/// </summary>
public record TestEntityZeroOrOneDeleted(TestEntityZeroOrOne TestEntityZeroOrOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    public virtual SecondTestEntityZeroOrOne? SecondTestEntityZeroOrOneRelationship { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity SecondTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text? SecondTestEntityZeroOrOneRelationshipId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}