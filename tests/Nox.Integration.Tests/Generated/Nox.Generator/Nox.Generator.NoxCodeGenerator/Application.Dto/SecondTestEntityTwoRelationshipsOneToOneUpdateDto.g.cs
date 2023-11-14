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
public partial class SecondTestEntityTwoRelationshipsOneToOneUpdateDto : SecondTestEntityTwoRelationshipsOneToOneUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityTwoRelationshipsOneToOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityTwoRelationshipsOneToOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;
}