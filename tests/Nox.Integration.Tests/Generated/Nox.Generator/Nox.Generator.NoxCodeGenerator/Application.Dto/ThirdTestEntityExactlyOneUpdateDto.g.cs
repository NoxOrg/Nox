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
/// Entity created for testing database.
/// </summary>
public partial class ThirdTestEntityExactlyOneUpdateDto : ThirdTestEntityExactlyOneUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class ThirdTestEntityExactlyOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.ThirdTestEntityExactlyOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
}