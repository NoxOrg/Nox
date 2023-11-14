// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing constraints
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyUpdateDto : IEntityDto<DomainNamespace.EntityUniqueConstraintsRelatedForeignKey>
{
    /// <summary>
    ///  
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? TextField { get; set; }

    /// <summary>
    /// EntityUniqueConstraintsRelatedForeignKey for ZeroOrMany EntityUniqueConstraintsWithForeignKeys
    /// </summary>
    public List<System.Guid> EntityUniqueConstraintsWithForeignKeysId { get; set; } = new();
}