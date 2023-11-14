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
public partial class TestEntityZeroOrManyToZeroOrOneUpdateDto : TestEntityZeroOrManyToZeroOrOneUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityZeroOrManyToZeroOrOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityZeroOrManyToZeroOrOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
    /// </summary>
    public virtual List<System.String> TestEntityZeroOrOneToZeroOrManiesId { get; set; } = new();
}