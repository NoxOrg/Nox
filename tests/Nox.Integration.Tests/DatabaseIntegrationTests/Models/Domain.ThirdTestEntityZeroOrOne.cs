// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class ThirdTestEntityZeroOrOne:ThirdTestEntityZeroOrOneBase
{

}
/// <summary>
/// Record for ThirdTestEntityZeroOrOne created event.
/// </summary>
public record ThirdTestEntityZeroOrOneCreated(ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityZeroOrOne updated event.
/// </summary>
public record ThirdTestEntityZeroOrOneUpdated(ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for ThirdTestEntityZeroOrOne deleted event.
/// </summary>
public record ThirdTestEntityZeroOrOneDeleted(ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// ThirdTestEntityZeroOrOne Test entity relationship to ThirdTestEntityExactlyOne ZeroOrOne ThirdTestEntityExactlyOnes
    /// </summary>
    public virtual ThirdTestEntityExactlyOne? ThirdTestEntityExactlyOneRelationship { get; private set; } = null!;

    public virtual void CreateRefToThirdTestEntityExactlyOneRelationship(ThirdTestEntityExactlyOne relatedThirdTestEntityExactlyOne)
    {
        ThirdTestEntityExactlyOneRelationship = relatedThirdTestEntityExactlyOne;
    }

    public virtual void DeleteRefToThirdTestEntityExactlyOneRelationship(ThirdTestEntityExactlyOne relatedThirdTestEntityExactlyOne)
    {
        ThirdTestEntityExactlyOneRelationship = null;
    }

    public virtual void DeleteAllRefToThirdTestEntityExactlyOneRelationship()
    {
        ThirdTestEntityExactlyOneRelationship = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}