// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for ThirdTestEntityOneOrMany created event.
/// </summary>
public record ThirdTestEntityOneOrManyCreated(ThirdTestEntityOneOrMany ThirdTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// Record for ThirdTestEntityOneOrMany updated event.
/// </summary>
public record ThirdTestEntityOneOrManyUpdated(ThirdTestEntityOneOrMany ThirdTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// Record for ThirdTestEntityOneOrMany deleted event.
/// </summary>
public record ThirdTestEntityOneOrManyDeleted(ThirdTestEntityOneOrMany ThirdTestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class ThirdTestEntityOneOrMany : AuditableEntityBase, IEntityConcurrent
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
    /// ThirdTestEntityOneOrMany Test entity relationship to ThirdTestEntityZeroOrMany OneOrMany ThirdTestEntityZeroOrManies
    /// </summary>
    public virtual List<ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}