// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

/// <summary>
/// Language.
/// </summary>
internal partial class LanguageLocalized : IEntityConcurrent
{
    /// <summary>
    /// Language unique identifier (Required).
    /// </summary>
    public Nox.Types.CountryCode2 Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    /// Country's name (Optional).
    /// </summary>
    public Nox.Types.Text? Name { get; set; } = null!;

    public virtual ClientApi.Domain.Language Language { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}