// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public record SecondTestEntityOwnedRelationshipZeroOrOneKeyDto();

/// <summary>
/// Update SecondTestEntityOwnedRelationshipZeroOrOne
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipZeroOrOneDto : SecondTestEntityOwnedRelationshipZeroOrOneDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipZeroOrOneDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityOwnedRelationshipZeroOrOne>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => DomainNamespace.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField2", new [] { "TextTestField2 is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String TextTestField2 { get; set; } = default!;
}