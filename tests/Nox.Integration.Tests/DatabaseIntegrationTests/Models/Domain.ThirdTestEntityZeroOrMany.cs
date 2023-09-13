// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for ThirdTestEntityZeroOrMany created event.
/// </summary>
public record ThirdTestEntityZeroOrManyCreated(ThirdTestEntityZeroOrMany ThirdTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for ThirdTestEntityZeroOrMany updated event.
/// </summary>
public record ThirdTestEntityZeroOrManyUpdated(ThirdTestEntityZeroOrMany ThirdTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for ThirdTestEntityZeroOrMany deleted event.
/// </summary>
public record ThirdTestEntityZeroOrManyDeleted(ThirdTestEntityZeroOrMany ThirdTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class ThirdTestEntityZeroOrMany : AuditableEntityBase, IEntityConcurrent
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
    /// ThirdTestEntityZeroOrMany Test entity relationship to ThirdTestEntityOneOrMany ZeroOrMany ThirdTestEntityOneOrManies
    /// </summary>
    public virtual List<ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}