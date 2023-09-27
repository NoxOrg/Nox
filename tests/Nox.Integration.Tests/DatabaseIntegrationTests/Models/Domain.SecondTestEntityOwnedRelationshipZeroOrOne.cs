// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipZeroOrOne:SecondTestEntityOwnedRelationshipZeroOrOneBase
{

}
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
public abstract class SecondTestEntityOwnedRelationshipZeroOrOneBase : EntityBase, IOwnedEntity
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

}