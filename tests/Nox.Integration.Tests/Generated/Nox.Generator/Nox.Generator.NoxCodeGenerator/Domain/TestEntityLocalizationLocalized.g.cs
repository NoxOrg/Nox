// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

using TestWebAppDomain = TestWebApp.Domain;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationLocalized : IEntity, IEtag 
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Text? TextFieldToLocalize { get; set; } = null!;

    public virtual TestWebAppDomain.TestEntityLocalization TestEntityLocalization { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}