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
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipOneOrManyUpdateDto : TestEntityOwnedRelationshipOneOrManyUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipOneOrManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipOneOrMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String? TextTestField { get; set; }
    /// <summary>
    /// TestEntityOwnedRelationshipOneOrMany Test entity relationship to SecondTestEntityOwnedRelationshipOneOrMany OneOrMany SecEntityOwnedRelOneOrManies
    /// </summary>
    public virtual List<SecEntityOwnedRelOneOrManyUpsertDto> SecEntityOwnedRelOneOrManies { get; set; } = new();
}