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
/// Workplace Address.
/// </summary>
public partial class WorkplaceAddressLocalized : IEntity, IEtag
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Guid Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    /// Address line (Optional).
    /// </summary>
    public Nox.Types.Text? AddressLine { get; set; } = null!;

    public virtual ClientApiDomain.WorkplaceAddress WorkplaceAddress { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}