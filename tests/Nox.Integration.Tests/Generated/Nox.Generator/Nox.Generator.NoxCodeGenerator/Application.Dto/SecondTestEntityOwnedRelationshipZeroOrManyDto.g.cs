﻿// Generated

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

public record SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(System.String keyId);

/// <summary>
/// Update SecondTestEntityOwnedRelationshipZeroOrMany
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipZeroOrManyDto : SecondTestEntityOwnedRelationshipZeroOrManyDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipZeroOrManyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityOwnedRelationshipZeroOrMany>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => DomainNamespace.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField2", new [] { "TextTestField2 is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String TextTestField2 { get; set; } = default!;
}