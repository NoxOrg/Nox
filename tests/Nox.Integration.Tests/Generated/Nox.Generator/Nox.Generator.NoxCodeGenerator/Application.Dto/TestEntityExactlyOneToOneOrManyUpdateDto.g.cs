// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;
namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityExactlyOneToOneOrManyUpdateDto : IEntityDto<TestEntityExactlyOneToOneOrManyEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityExactlyOneToOneOrMany Test entity relationship to TestEntityOneOrManyToExactlyOne ExactlyOne TestEntityOneOrManyToExactlyOnes
    /// </summary>
    [Required(ErrorMessage = "TestEntityOneOrManyToExactlyOne is required")]
    public System.String TestEntityOneOrManyToExactlyOneId { get; set; } = default!;
}