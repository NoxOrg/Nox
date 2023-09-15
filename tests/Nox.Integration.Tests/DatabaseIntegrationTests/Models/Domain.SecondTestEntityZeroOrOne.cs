// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityZeroOrOne:SecondTestEntityZeroOrOneBase
{

}
/// <summary>
/// Record for SecondTestEntityZeroOrOne created event.
/// </summary>
public record SecondTestEntityZeroOrOneCreated(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityZeroOrOne updated event.
/// </summary>
public record SecondTestEntityZeroOrOneUpdated(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityZeroOrOne deleted event.
/// </summary>
public record SecondTestEntityZeroOrOneDeleted(SecondTestEntityZeroOrOne SecondTestEntityZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// SecondTestEntityZeroOrOne Test entity relationship to TestEntity ZeroOrOne TestEntityZeroOrOnes
    /// </summary>
    public virtual TestEntityZeroOrOne? TestEntityZeroOrOneRelationship { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOne(TestEntityZeroOrOne relatedTestEntityZeroOrOne)
    {
        TestEntityZeroOrOneRelationship = relatedTestEntityZeroOrOne;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}