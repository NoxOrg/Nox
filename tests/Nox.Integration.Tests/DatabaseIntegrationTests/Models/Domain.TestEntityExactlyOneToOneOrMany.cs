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
public partial class TestEntityExactlyOneToOneOrMany : AuditableEntityBase
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
    /// TestEntityExactlyOneToOneOrMany Test entity relationship to TestEntityOneOrManyToExactlyOne ExactlyOne TestEntityOneOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityOneOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityOneOrManyToExactlyOneId { get; set; } = null!;
}