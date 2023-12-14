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

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOneCreateDto : TestEntityZeroOrOneCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneCreateDtoBase : IEntityDto<DomainNamespace.TestEntityZeroOrOne>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public virtual System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String? TextTestField { get; set; }

    /// <summary>
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    public System.String? SecondTestEntityZeroOrOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual SecondTestEntityZeroOrOneCreateDto? SecondTestEntityZeroOrOne { get; set; } = default!;
}