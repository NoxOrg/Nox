// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuid : AuditableEntityBase
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid Id { get; set; } = null!;

    public void EnsureId()
    {
        if (Id is null)
        {
            Id = Nuid.From("TestEntityWithNuid." + string.Join(".", Name.Value.ToString()));
        }
        else
        {
            var currentNuid = Nuid.From("TestEntityWithNuid." + string.Join(".", Name.Value.ToString()));
            if (Id != currentNuid)
            {
                throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
            }
        }
    }

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
}