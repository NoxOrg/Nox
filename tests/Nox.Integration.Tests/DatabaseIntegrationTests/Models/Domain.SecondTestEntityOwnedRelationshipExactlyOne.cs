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
<<<<<<< HEAD:tests/Nox.Integration.Tests/DatabaseIntegrationTests/Models/Entities.SecondTestEntityOwnedRelationshipExactlyOne.cs
public partial class SecondTestEntityOwnedRelationshipExactlyOne:EntityBase, IOwnedEntity
=======
public partial class SecondTestEntityOwnedRelationshipExactlyOne : EntityBase, IOwnedEntity
>>>>>>> main:tests/Nox.Integration.Tests/DatabaseIntegrationTests/Models/Domain.SecondTestEntityOwnedRelationshipExactlyOne.cs
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