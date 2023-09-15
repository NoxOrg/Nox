// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityExactlyOneToZeroOrOne:TestEntityExactlyOneToZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne created event.
/// </summary>
public record TestEntityExactlyOneToZeroOrOneCreated(TestEntityExactlyOneToZeroOrOne TestEntityExactlyOneToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne updated event.
/// </summary>
public record TestEntityExactlyOneToZeroOrOneUpdated(TestEntityExactlyOneToZeroOrOne TestEntityExactlyOneToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne deleted event.
/// </summary>
public record TestEntityExactlyOneToZeroOrOneDeleted(TestEntityExactlyOneToZeroOrOne TestEntityExactlyOneToZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrOneToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrOneToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOne relatedTestEntityZeroOrOneToExactlyOne)
    {
        TestEntityZeroOrOneToExactlyOne = relatedTestEntityZeroOrOneToExactlyOne;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}