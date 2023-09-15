// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipZeroOrOne:TestEntityOwnedRelationshipZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne created event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneCreated(TestEntityOwnedRelationshipZeroOrOne TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne updated event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneUpdated(TestEntityOwnedRelationshipZeroOrOne TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne deleted event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneDeleted(TestEntityOwnedRelationshipZeroOrOne TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityOwnedRelationshipZeroOrOne Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrOne ZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOnes
    /// </summary>
     public virtual SecondTestEntityOwnedRelationshipZeroOrOne? SecondTestEntityOwnedRelationshipZeroOrOne { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}