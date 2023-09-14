// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class ThirdTestEntityOneOrMany:ThirdTestEntityOneOrManyBase
{

}
/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class ThirdTestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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
    /// ThirdTestEntityOneOrMany Test entity relationship to ThirdTestEntityZeroOrMany OneOrMany ThirdTestEntityZeroOrManies
    /// </summary>
    public virtual List<ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManyRelationship { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}