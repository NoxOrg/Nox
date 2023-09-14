// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class SecondTestEntityZeroOrMany:SecondTestEntityZeroOrManyBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// SecondTestEntityZeroOrMany Test entity relationship to TestEntityZeroOrMany ZeroOrMany TestEntityZeroOrManies
    /// </summary>
    public virtual List<TestEntityZeroOrMany> TestEntityZeroOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}