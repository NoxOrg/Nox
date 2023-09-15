// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOneOrMany:SecondTestEntityOneOrManyBase
{

}
/// <summary>
/// Record for SecondTestEntityOneOrMany created event.
/// </summary>
public record SecondTestEntityOneOrManyCreated(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOneOrMany updated event.
/// </summary>
public record SecondTestEntityOneOrManyUpdated(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOneOrMany deleted event.
/// </summary>
public record SecondTestEntityOneOrManyDeleted(SecondTestEntityOneOrMany SecondTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// SecondTestEntityOneOrMany Test entity relationship to TestEntityOneOrMany OneOrMany TestEntityOneOrManies
    /// </summary>
    public virtual List<TestEntityOneOrMany> TestEntityOneOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}