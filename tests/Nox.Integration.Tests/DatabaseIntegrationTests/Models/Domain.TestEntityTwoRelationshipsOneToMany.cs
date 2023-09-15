// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsOneToMany:TestEntityTwoRelationshipsOneToManyBase
{

}
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany created event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyCreated(TestEntityTwoRelationshipsOneToMany TestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany updated event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyUpdated(TestEntityTwoRelationshipsOneToMany TestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany deleted event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyDeleted(TestEntityTwoRelationshipsOneToMany TestEntityTwoRelationshipsOneToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityTwoRelationshipsOneToMany First relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipOne { get; set; } = new();

    public virtual void CreateRefToSecondTestEntityTwoRelationshipsOneToManyTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOne.Add(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany Second relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipTwo { get; set; } = new();

    public virtual void CreateRefToSecondTestEntityTwoRelationshipsOneToManyTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwo.Add(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}