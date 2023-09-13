// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrManyCreated(SecondTestEntityOwnedRelationshipZeroOrMany SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrManyUpdated(SecondTestEntityOwnedRelationshipZeroOrMany SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrMany deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrManyDeleted(SecondTestEntityOwnedRelationshipZeroOrMany SecondTestEntityOwnedRelationshipZeroOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipZeroOrMany : EntityBase, IOwnedEntity
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

}