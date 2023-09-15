// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityExactlyOne:SecondTestEntityExactlyOneBase
{

}
/// <summary>
/// Record for SecondTestEntityExactlyOne created event.
/// </summary>
public record SecondTestEntityExactlyOneCreated(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityExactlyOne updated event.
/// </summary>
public record SecondTestEntityExactlyOneUpdated(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityExactlyOne deleted event.
/// </summary>
public record SecondTestEntityExactlyOneDeleted(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    public virtual TestEntityExactlyOne TestEntityExactlyOneRelationship { get; set; } = null!;

    public virtual void CreateRefToTestEntityExactlyOneRelationship(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        TestEntityExactlyOneRelationship = relatedTestEntityExactlyOne;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}