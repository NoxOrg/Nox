// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOne : AuditableEntityBase
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
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    public virtual SecondTestEntityZeroOrOne? SecondTestEntityZeroOrOne { get; set; } = null!;
    public SecondTestEntityZeroOrOne? SecondTestEntityZeroOrOneRelationship => SecondTestEntityZeroOrOne;
    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity SecondTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text? SecondTestEntityZeroOrOneId { get; set; } = null!;
}