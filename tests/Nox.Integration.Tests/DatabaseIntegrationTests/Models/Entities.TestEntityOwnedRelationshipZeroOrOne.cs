// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipZeroOrOne : AuditableEntityBase
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
    /// TestEntityOwnedRelationshipZeroOrOne Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrOne ZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOnes
    /// </summary>
     public virtual SecondTestEntityOwnedRelationshipZeroOrOne? SecondTestEntityOwnedRelationshipZeroOrOne { get; set; } = null!;
}