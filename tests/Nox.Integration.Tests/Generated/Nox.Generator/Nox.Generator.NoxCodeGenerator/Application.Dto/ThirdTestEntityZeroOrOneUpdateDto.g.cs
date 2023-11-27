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
public partial class ThirdTestEntityZeroOrOneUpdateDto : ThirdTestEntityZeroOrOneUpdateDtoBase
{

}

/// <summary>
/// Patch entity ThirdTestEntityZeroOrOne: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class ThirdTestEntityZeroOrOnePatchDto: { { className} }
{

}

/// <summary>
/// 
/// </summary>
public partial class ThirdTestEntityZeroOrOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.ThirdTestEntityZeroOrOne>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;
}