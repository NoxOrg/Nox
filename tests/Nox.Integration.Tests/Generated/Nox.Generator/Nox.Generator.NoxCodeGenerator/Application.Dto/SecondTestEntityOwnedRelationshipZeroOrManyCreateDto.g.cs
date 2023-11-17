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
public partial class SecondTestEntityOwnedRelationshipZeroOrManyCreateDto : SecondTestEntityOwnedRelationshipZeroOrManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipZeroOrManyCreateDtoBase : IEntityDto<DomainNamespace.SecondTestEntityOwnedRelationshipZeroOrMany>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;
}