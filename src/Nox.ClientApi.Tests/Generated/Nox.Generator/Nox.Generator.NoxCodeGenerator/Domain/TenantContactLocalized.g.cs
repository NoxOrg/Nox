// Generated

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
/// Tenant Contact.
/// </summary>
internal partial class TenantContactLocalized : IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Nuid TenantId { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    /// Teanant Brand Description (Optional).
    /// </summary>
    public Nox.Types.Text? Description { get; set; } = null!;

    public virtual ClientApiDomain.TenantContact TenantContact { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}