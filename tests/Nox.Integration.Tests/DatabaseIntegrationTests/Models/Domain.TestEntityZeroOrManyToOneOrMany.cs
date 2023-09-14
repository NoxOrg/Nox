// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrManyToOneOrMany:TestEntityZeroOrManyToOneOrManyBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToOneOrManyBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

    /// <summary>
    /// TestEntityZeroOrManyToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrMany ZeroOrMany TestEntityOneOrManyToZeroOrManies
    /// </summary>
    public virtual List<TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}