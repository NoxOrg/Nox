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

public partial class TestEntityZeroOrOneToZeroOrManyCreateDto : TestEntityZeroOrOneToZeroOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToZeroOrManyCreateDtoBase : IEntityDto<DomainNamespace.TestEntityZeroOrOneToZeroOrMany>
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityZeroOrOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToZeroOrOne ZeroOrOne TestEntityZeroOrManyToZeroOrOnes
    /// </summary>
    public System.String? TestEntityZeroOrManyToZeroOrOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TestEntityZeroOrManyToZeroOrOneCreateDto? TestEntityZeroOrManyToZeroOrOne { get; set; } = default!;
}