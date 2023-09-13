// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneCreated(SecondTestEntityOwnedRelationshipZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneUpdated(SecondTestEntityOwnedRelationshipZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipZeroOrOne deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipZeroOrOneDeleted(SecondTestEntityOwnedRelationshipZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipZeroOrOne : EntityBase, IOwnedEntity
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id1 { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

}