// Generated
 
#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing localization.
/// </summary>
internal partial class TestEntityLocalizationLocalized : IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;
    
    
        /// <summary>
        ///  (Required).
        /// </summary>
        public Nox.Types.Text TextFieldToLocalize { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}