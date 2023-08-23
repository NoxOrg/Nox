// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

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