// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

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
    /// SecondTestEntity Test entity relationship to TestEntity ZeroOrMany TestEntities
    /// </summary>
    public virtual List<TestEntity> TestEntities { get; set; } = new List<TestEntity>();

    public List<TestEntity> TestEntityRelationship => TestEntities;
}
