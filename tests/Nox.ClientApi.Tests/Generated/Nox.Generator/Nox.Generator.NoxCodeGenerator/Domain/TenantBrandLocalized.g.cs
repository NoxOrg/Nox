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
/// Tenant Brand.
/// </summary>
public partial class TenantBrandLocalized : IEntity, IEtag
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    /// Teanant Brand Description (Optional).
    /// </summary>
    public Nox.Types.Text? Description { get; set; } = null!;

    public virtual ClientApiDomain.TenantBrand TenantBrand { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}