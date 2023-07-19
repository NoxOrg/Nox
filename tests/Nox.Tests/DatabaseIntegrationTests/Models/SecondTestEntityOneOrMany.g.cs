// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOneOrMany : AuditableEntityBase
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
    /// SecondTestEntityOneOrMany Test entity relationship to TestEntityOneOrMany OneOrMany TestEntityOneOrManies
    /// </summary>
    public virtual List<TestEntityOneOrMany> TestEntityOneOrManies { get; set; } = new List<TestEntityOneOrMany>();

    public List<TestEntityOneOrMany> TestEntityRelationship => TestEntityOneOrManies;
}
