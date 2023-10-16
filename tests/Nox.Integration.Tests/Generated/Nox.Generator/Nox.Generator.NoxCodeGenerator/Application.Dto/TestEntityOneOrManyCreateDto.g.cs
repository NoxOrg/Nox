// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityOneOrManyCreateDto : TestEntityOneOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityOneOrManyCreateDtoBase : IEntityDto<TestEntityOneOrManyEntity>
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
    /// TestEntityOneOrMany Test entity relationship to SecondTestEntityOneOrMany OneOrMany SecondTestEntityOneOrManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<SecondTestEntityOneOrManyCreateDto> SecondTestEntityOneOrManyRelationship { get; set; } = new();
}