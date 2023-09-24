// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsOneToOne:TestEntityTwoRelationshipsOneToOneBase
{

}
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToOne created event.
/// </summary>
public record TestEntityTwoRelationshipsOneToOneCreated(TestEntityTwoRelationshipsOneToOne TestEntityTwoRelationshipsOneToOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToOne updated event.
/// </summary>
public record TestEntityTwoRelationshipsOneToOneUpdated(TestEntityTwoRelationshipsOneToOne TestEntityTwoRelationshipsOneToOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToOne deleted event.
/// </summary>
public record TestEntityTwoRelationshipsOneToOneDeleted(TestEntityTwoRelationshipsOneToOne TestEntityTwoRelationshipsOneToOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityTwoRelationshipsOneToOne First relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual SecondTestEntityTwoRelationshipsOneToOne TestRelationshipOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityTwoRelationshipsOneToOne
    /// </summary>
    public Nox.Types.Text TestRelationshipOneId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipOne = relatedSecondTestEntityTwoRelationshipsOneToOne;
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToOne Second relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual SecondTestEntityTwoRelationshipsOneToOne TestRelationshipTwo { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityTwoRelationshipsOneToOne
    /// </summary>
    public Nox.Types.Text TestRelationshipTwoId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipTwo = relatedSecondTestEntityTwoRelationshipsOneToOne;
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToOne relatedSecondTestEntityTwoRelationshipsOneToOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}