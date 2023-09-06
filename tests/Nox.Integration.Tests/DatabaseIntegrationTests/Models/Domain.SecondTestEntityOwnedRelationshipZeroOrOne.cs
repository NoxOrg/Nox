// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// .
/// </summary>
<<<<<<< HEAD:tests/Nox.Integration.Tests/DatabaseIntegrationTests/Models/Entities.SecondTestEntityOwnedRelationshipZeroOrOne.cs
public partial class SecondTestEntityOwnedRelationshipZeroOrOne:EntityBase, IOwnedEntity
=======
public partial class SecondTestEntityOwnedRelationshipZeroOrOne : EntityBase, IOwnedEntity
>>>>>>> main:tests/Nox.Integration.Tests/DatabaseIntegrationTests/Models/Domain.SecondTestEntityOwnedRelationshipZeroOrOne.cs
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id1 { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
}