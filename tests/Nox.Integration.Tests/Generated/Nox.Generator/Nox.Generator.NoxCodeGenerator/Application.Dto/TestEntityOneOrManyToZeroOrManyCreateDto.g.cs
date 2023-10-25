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

public partial class TestEntityOneOrManyToZeroOrManyCreateDto : TestEntityOneOrManyToZeroOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityOneOrManyToZeroOrManyCreateDtoBase : IEntityDto<DomainNamespace.TestEntityOneOrManyToZeroOrMany>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityOneOrManyToZeroOrMany Test entity relationship to TestEntityZeroOrManyToOneOrMany OneOrMany TestEntityZeroOrManyToOneOrManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<TestEntityZeroOrManyToOneOrManyCreateDto> TestEntityZeroOrManyToOneOrMany { get; set; } = new();
}