﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

using ClientApiDomain = ClientApi.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Workplace.
/// </summary>
internal partial class WorkplaceLocalized : IEntityConcurrent
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public Nox.Types.Text? Description { get; set; } = null!;

    public virtual ClientApiDomain.Workplace Workplace { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}