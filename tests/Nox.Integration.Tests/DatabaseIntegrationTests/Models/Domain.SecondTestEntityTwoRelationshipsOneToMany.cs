// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityTwoRelationshipsOneToMany:SecondTestEntityTwoRelationshipsOneToManyBase
{

}
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany created event.
/// </summary>
public record SecondTestEntityTwoRelationshipsOneToManyCreated(SecondTestEntityTwoRelationshipsOneToMany SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany updated event.
/// </summary>
public record SecondTestEntityTwoRelationshipsOneToManyUpdated(SecondTestEntityTwoRelationshipsOneToMany SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany deleted event.
/// </summary>
public record SecondTestEntityTwoRelationshipsOneToManyDeleted(SecondTestEntityTwoRelationshipsOneToMany SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToManyBase : EntityBase, IEntityConcurrent
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
    /// SecondTestEntityTwoRelationshipsOneToMany First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToMany? TestRelationshipOneOnOtherSide { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityTwoRelationshipsOneToMany
    /// </summary>
    public Nox.Types.Text? TestRelationshipOneOnOtherSideId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsOneToMany relatedTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOneOnOtherSide = relatedTestEntityTwoRelationshipsOneToMany;
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToMany Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToMany? TestRelationshipTwoOnOtherSide { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityTwoRelationshipsOneToMany
    /// </summary>
    public Nox.Types.Text? TestRelationshipTwoOnOtherSideId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToMany relatedTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwoOnOtherSide = relatedTestEntityTwoRelationshipsOneToMany;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}