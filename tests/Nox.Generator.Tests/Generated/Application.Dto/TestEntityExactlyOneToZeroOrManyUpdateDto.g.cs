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
public partial class TestEntityExactlyOneToZeroOrManyUpdateDto : TestEntityExactlyOneToZeroOrManyUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityExactlyOneToZeroOrManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityExactlyOneToZeroOrMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
}