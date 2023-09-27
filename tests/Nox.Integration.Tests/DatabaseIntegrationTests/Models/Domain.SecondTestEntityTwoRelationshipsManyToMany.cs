// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityTwoRelationshipsManyToMany:SecondTestEntityTwoRelationshipsManyToManyBase
{

}
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany created event.
/// </summary>
public record SecondTestEntityTwoRelationshipsManyToManyCreated(SecondTestEntityTwoRelationshipsManyToMany SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
public record SecondTestEntityTwoRelationshipsManyToManyUpdated(SecondTestEntityTwoRelationshipsManyToMany SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
public record SecondTestEntityTwoRelationshipsManyToManyDeleted(SecondTestEntityTwoRelationshipsManyToMany SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsManyToManyBase : EntityBase, IEntityConcurrent
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
    /// SecondTestEntityTwoRelationshipsManyToMany First relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<TestEntityTwoRelationshipsManyToMany> TestRelationshipOneOnOtherSide { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Add(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Remove(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOneOnOtherSide()
    {
        TestRelationshipOneOnOtherSide.Clear();
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany Second relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<TestEntityTwoRelationshipsManyToMany> TestRelationshipTwoOnOtherSide { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Add(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Remove(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwoOnOtherSide()
    {
        TestRelationshipTwoOnOtherSide.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}