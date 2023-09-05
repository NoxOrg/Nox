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
public partial class TestEntityOneOrManyToZeroOrMany : AuditableEntityBase, IConcurrent
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
    /// TestEntityOneOrManyToZeroOrMany Test entity relationship to TestEntityZeroOrManyToOneOrMany OneOrMany TestEntityZeroOrManyToOneOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}