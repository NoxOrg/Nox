// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityExactlyOneToZeroOrManyCreateDto : TestEntityExactlyOneToZeroOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrManyCreateDtoBase : IEntityDto<TestEntityExactlyOneToZeroOrMany>
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
    /// TestEntityExactlyOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToExactlyOne ExactlyOne TestEntityZeroOrManyToExactlyOnes
    /// </summary>
    public System.String? TestEntityZeroOrManyToExactlyOneId { get; set; } = default!;
    public virtual TestEntityZeroOrManyToExactlyOneCreateDto? TestEntityZeroOrManyToExactlyOne { get; set; } = default!;
}