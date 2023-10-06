// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;
namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityTwoRelationshipsManyToManyUpdateDto : IEntityDto<SecondTestEntityTwoRelationshipsManyToManyEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public System.String TextTestField2 { get; set; } = default!;
}