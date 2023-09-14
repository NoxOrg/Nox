// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipOneOrMany:SecondTestEntityOwnedRelationshipOneOrManyBase
{

}
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany created event.
/// </summary>
public record SecondTestEntityOwnedRelationshipOneOrManyCreated(SecondTestEntityOwnedRelationshipOneOrMany SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
public record SecondTestEntityOwnedRelationshipOneOrManyUpdated(SecondTestEntityOwnedRelationshipOneOrMany SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
public record SecondTestEntityOwnedRelationshipOneOrManyDeleted(SecondTestEntityOwnedRelationshipOneOrMany SecondTestEntityOwnedRelationshipOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipOneOrManyBase : EntityBase, IOwnedEntity
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