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

public partial class TestEntityExactlyOneCreateDto : TestEntityExactlyOneCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityExactlyOneCreateDtoBase : IEntityDto<DomainNamespace.TestEntityExactlyOne>
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
    /// TestEntityExactlyOne Test entity relationship to SecondTestEntityExactlyOneRelationship ExactlyOne SecondTestEntityExactlyOnes
    /// </summary>
    public System.String? SecondTestEntityExactlyOneRelationshipId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual SecondTestEntityExactlyOneCreateDto? SecondTestEntityExactlyOneRelationship { get; set; } = default!;
}