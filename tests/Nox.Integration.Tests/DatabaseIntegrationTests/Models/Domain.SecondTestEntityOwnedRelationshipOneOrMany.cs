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
<<<<<<< HEAD:tests/Nox.Integration.Tests/DatabaseIntegrationTests/Models/Entities.SecondTestEntityOwnedRelationshipOneOrMany.cs
public partial class SecondTestEntityOwnedRelationshipOneOrMany:EntityBase, IOwnedEntity
=======
public partial class SecondTestEntityOwnedRelationshipOneOrMany : EntityBase, IOwnedEntity
>>>>>>> main:tests/Nox.Integration.Tests/DatabaseIntegrationTests/Models/Domain.SecondTestEntityOwnedRelationshipOneOrMany.cs
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