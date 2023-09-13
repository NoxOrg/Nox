// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne created event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneCreated(TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne updated event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneUpdated(TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne) : IDomainEvent;

/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne deleted event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneDeleted(TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOneToExactlyOne : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;

    /// <summary>
    /// TestEntityZeroOrOneToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrOne ZeroOrOne TestEntityExactlyOneToZeroOrOnes
    /// </summary>
    public virtual TestEntityExactlyOneToZeroOrOne? TestEntityExactlyOneToZeroOrOne { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}