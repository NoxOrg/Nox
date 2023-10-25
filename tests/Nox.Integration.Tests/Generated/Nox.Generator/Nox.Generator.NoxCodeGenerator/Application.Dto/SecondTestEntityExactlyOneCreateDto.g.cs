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

public partial class SecondTestEntityExactlyOneCreateDto : SecondTestEntityExactlyOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityExactlyOneCreateDtoBase : IEntityDto<DomainNamespace.SecondTestEntityExactlyOne>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    public System.String? TestEntityExactlyOneRelationshipId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual TestEntityExactlyOneCreateDto? TestEntityExactlyOneRelationship { get; set; } = default!;
}