// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipZeroOrManyCreateDto : TestEntityOwnedRelationshipZeroOrManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipZeroOrManyCreateDtoBase : IEntityDto<DomainNamespace.TestEntityOwnedRelationshipZeroOrMany>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String? TextTestField { get; set; }

    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrMany Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrMany ZeroOrMany SecEntityOwnedRelZeroOrManies
    /// </summary>
    public virtual List<SecEntityOwnedRelZeroOrManyUpsertDto> SecEntityOwnedRelZeroOrManies { get; set; } = new();
}