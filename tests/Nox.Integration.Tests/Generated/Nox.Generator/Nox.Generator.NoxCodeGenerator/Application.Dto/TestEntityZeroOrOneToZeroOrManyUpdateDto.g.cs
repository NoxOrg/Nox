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
public partial class TestEntityZeroOrOneToZeroOrManyUpdateDto : TestEntityZeroOrOneToZeroOrManyUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityZeroOrOneToZeroOrManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityZeroOrOneToZeroOrMany>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityZeroOrOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToZeroOrOne ZeroOrOne TestEntityZeroOrManyToZeroOrOnes
    /// </summary>
    
    public virtual System.String? TestEntityZeroOrManyToZeroOrOneId { get; set; } = default!;
}