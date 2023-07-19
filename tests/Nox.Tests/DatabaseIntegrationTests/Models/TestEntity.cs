// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntity : AuditableEntityBase
{

    /// <summary>
    /// (Required)
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// (Required)
    /// </summary>
    public Text TextTestField { get; set; } = null!;

    /// <summary>
    /// TestEntity Test entity relelionship to SecondTestEntity OneOrMany SecondTestEntities
    /// </summary>
    public virtual List<SecondTestEntity> SecondTestEntities { get; set; } = new List<SecondTestEntity>();

    public List<SecondTestEntity> SecondTestEntityRelationship => SecondTestEntities;
}
