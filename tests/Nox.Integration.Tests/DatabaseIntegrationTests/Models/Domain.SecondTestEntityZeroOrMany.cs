// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for SecondTestEntityZeroOrMany created event.
/// </summary>
public record SecondTestEntityZeroOrManyCreated(SecondTestEntityZeroOrMany SecondTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityZeroOrMany updated event.
/// </summary>
public record SecondTestEntityZeroOrManyUpdated(SecondTestEntityZeroOrMany SecondTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityZeroOrMany deleted event.
/// </summary>
public record SecondTestEntityZeroOrManyDeleted(SecondTestEntityZeroOrMany SecondTestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityZeroOrMany : AuditableEntityBase, IEntityConcurrent
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
    /// SecondTestEntityZeroOrMany Test entity relationship to TestEntityZeroOrMany ZeroOrMany TestEntityZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrMany> TestEntityZeroOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}