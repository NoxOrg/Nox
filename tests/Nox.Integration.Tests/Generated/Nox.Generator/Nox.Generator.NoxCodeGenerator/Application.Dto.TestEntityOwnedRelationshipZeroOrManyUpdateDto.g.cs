// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;
namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipZeroOrManyUpdateDto : IEntityDto<TestEntityOwnedRelationshipZeroOrManyEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public System.String TextTestField { get; set; } = default!;
}