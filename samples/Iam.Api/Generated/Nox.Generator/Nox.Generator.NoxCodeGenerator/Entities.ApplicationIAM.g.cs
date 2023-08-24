// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace IamApi.Domain;

/// <summary>
/// ApplicationIAM.
/// </summary>
public partial class ApplicationIAM : AuditableEntityBase
{
    /// <summary>
    /// Application Id (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;
}