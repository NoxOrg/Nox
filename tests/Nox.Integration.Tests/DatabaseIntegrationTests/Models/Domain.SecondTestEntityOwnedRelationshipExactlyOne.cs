// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipExactlyOneCreated(SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipExactlyOneUpdated(SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// Record for SecondTestEntityOwnedRelationshipExactlyOne deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipExactlyOneDeleted(SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipExactlyOne : EntityBase, IOwnedEntity
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