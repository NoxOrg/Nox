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
public partial class SecondTestEntityExactlyOneUpdateDto : SecondTestEntityExactlyOneUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityExactlyOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityExactlyOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    [Required(ErrorMessage = "TestEntityExactlyOne is required")]
    public virtual System.String TestEntityExactlyOneId { get; set; } = default!;
}