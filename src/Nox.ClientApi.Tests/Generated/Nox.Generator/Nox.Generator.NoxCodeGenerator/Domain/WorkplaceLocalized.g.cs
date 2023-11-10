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
/// Workplace.
/// </summary>
[PrimaryKey(nameof(Id),nameof(CultureCode))]
internal partial class WorkplaceLocalized : IEntity, IEntityConcurrent
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public Nox.Types.Nuid Id { get; set; } = null!;

    public Nox.Types.CultureCode CultureCode { get; set; } = null!;
    
    
        /// <summary>
        /// Workplace Description (Optional).
        /// </summary>
        public Nox.Types.Text? Description { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}