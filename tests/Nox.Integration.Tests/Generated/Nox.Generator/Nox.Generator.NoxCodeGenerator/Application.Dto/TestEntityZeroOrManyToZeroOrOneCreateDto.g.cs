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
/// .
/// </summary>
public partial class TestEntityZeroOrManyToZeroOrOneCreateDto : TestEntityZeroOrManyToZeroOrOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToZeroOrOneCreateDtoBase : IEntityDto<DomainNamespace.TestEntityZeroOrManyToZeroOrOne>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String? TextTestField2 { get; set; }

    /// <summary>
    /// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
    /// </summary>
    public virtual List<System.String> TestEntityZeroOrOneToZeroOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TestEntityZeroOrOneToZeroOrManyCreateDto> TestEntityZeroOrOneToZeroOrManies { get; set; } = new();
}