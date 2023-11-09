// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityZeroOrOneUpdateDto : IEntityDto<DomainNamespace.SecondTestEntityZeroOrOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityZeroOrOne Test entity relationship to TestEntity ZeroOrOne TestEntityZeroOrOnes
    /// </summary>
    
    public System.String? TestEntityZeroOrOneId { get; set; } = default!;
}