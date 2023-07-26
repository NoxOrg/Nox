// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityExactlyOne : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>

    public virtual TestEntityExactlyOne TestEntityExactlyOne { get; set; } = null!;
}