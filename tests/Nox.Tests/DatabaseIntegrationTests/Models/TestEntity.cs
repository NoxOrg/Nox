// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntity : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text TextTestField { get; set; } = null!;
    /// <summary>
    /// TestEntity Test entity relationship to SecondTestEntity OneOrMany SecondTestEntities
    /// </summary>
    public virtual List<SecondTestEntity> SecondTestEntities { get; set; } = new();
    
    public List<SecondTestEntity> SecondTestEntityRelationship => SecondTestEntities;
}