// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class TestEntityExactlyOneToZeroOrOneUpdateDto : TestEntityExactlyOneToZeroOrOneUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityExactlyOneToZeroOrOneUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String? TextTestField2 { get; set; }
}