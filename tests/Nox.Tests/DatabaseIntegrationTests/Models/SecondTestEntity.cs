// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.Domain;

public partial class SecondTestEntity : AuditableEntityBase
{

    /// <summary>
    /// (Required)
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// (Required)
    /// </summary>
    public Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// SecondTestEntity Test entity relelionship to TestEntity ZeroOrMany TestEntities
    /// </summary>
    public virtual List<TestEntity> TestEntities { get; set; } = null!;

    [NotMapped]
    public List<TestEntity> TestEntityRelationship => TestEntities;
}
