// Generated
 
#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of countries.
/// </summary>
internal abstract partial class CountryLocalized : IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

      public Nox.Types.CultureCode CultureCode { get; set; } = null!;
    
    
        /// <summary>
        /// The country's official name (Required).
        /// </summary>
        public Nox.Types.Text FormalName { get; set; } = null!;
    
    
        /// <summary>
        /// The country's official ISO 4217 alpha-3 code (Required).
        /// </summary>
        public Nox.Types.Text AlphaCode3 { get; set; } = null!;
    
    
        /// <summary>
        /// The capital city of the country (Optional).
        /// </summary>
        public Nox.Types.Text? Capital { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}