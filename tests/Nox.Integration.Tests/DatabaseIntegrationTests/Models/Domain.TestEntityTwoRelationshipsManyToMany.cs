// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsManyToMany:TestEntityTwoRelationshipsManyToManyBase
{

}
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany created event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyCreated(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyUpdated(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyDeleted(TestEntityTwoRelationshipsManyToMany TestEntityTwoRelationshipsManyToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsManyToManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityTwoRelationshipsManyToMany First relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsManyToMany> TestRelationshipOne { get; set; } = new();

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany Second relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsManyToMany> TestRelationshipTwo { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}