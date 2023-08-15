// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipExactlyOne : AuditableEntityBase
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
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityOwnedRelationshipExactlyOne
    /// </summary>
    public Nox.Types.Text SecondTestEntityOwnedRelationshipExactlyOneId { get; set; } = null!;
}