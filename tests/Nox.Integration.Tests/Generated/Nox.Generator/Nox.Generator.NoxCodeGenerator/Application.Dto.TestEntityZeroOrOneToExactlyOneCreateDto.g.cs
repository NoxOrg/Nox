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

public partial class TestEntityZeroOrOneToExactlyOneCreateDto : TestEntityZeroOrOneToExactlyOneCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToExactlyOneCreateDtoBase : IEntityDto<TestEntityZeroOrOneToExactlyOne>
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
    /// TestEntityZeroOrOneToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrOne ZeroOrOne TestEntityExactlyOneToZeroOrOnes
    /// </summary>
    public System.String? TestEntityExactlyOneToZeroOrOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual TestEntityExactlyOneToZeroOrOneCreateDto? TestEntityExactlyOneToZeroOrOne { get; set; } = default!;
}