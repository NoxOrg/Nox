// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOneToOneOrMany : AuditableEntityBase
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;

    /// <summary>
    /// TestEntityZeroOrOneToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrOne ZeroOrOne TestEntityOneOrManyToZeroOrOnes
    /// </summary>
    public virtual TestEntityOneOrManyToZeroOrOne? TestEntityOneOrManyToZeroOrOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityOneOrManyToZeroOrOne
    /// </summary>
    public Nox.Types.Text? TestEntityOneOrManyToZeroOrOneId { get; set; } = null!;
}