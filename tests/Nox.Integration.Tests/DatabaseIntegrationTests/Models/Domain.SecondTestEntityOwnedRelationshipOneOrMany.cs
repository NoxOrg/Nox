// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class SecondTestEntityOwnedRelationshipOneOrMany:SecondTestEntityOwnedRelationshipOneOrManyBase
{

}
/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipOneOrManyBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

}