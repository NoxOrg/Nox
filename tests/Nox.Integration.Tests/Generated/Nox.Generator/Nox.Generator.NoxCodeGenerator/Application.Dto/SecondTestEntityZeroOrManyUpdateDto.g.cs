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
/// .
/// </summary>
public partial class SecondTestEntityZeroOrManyUpdateDto : IEntityDto<DomainNamespace.SecondTestEntityZeroOrMany>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityZeroOrMany Test entity relationship to TestEntityZeroOrMany ZeroOrMany TestEntityZeroOrManies
    /// </summary>
    public List<System.String> TestEntityZeroOrManyRelationshipId { get; set; } = new();
}