// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class MultipleIdsType : AuditableEntityBase
{

    /// <summary>
    /// First Id (Required).
    /// </summary>
    public Text Id1 { get; set; } = null!;

    /// <summary>
    /// Second Id (Required).
    /// </summary>
    public Text Id2 { get; set; } = null!;

    /// <summary>
    /// Name of the entity (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
}