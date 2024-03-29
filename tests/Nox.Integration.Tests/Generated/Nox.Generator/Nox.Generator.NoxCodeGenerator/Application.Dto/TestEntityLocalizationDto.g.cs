﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace TestWebApp.Application.Dto;

public record TestEntityLocalizationKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityLocalization
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationDto : TestEntityLocalizationDtoBase
{

}

/// <summary>
/// Entity created for testing localization.
/// </summary>
public abstract class TestEntityLocalizationDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextFieldToLocalize is not null)
            CollectValidationExceptions("TextFieldToLocalize", () => TestEntityLocalizationMetadata.CreateTextFieldToLocalize(this.TextFieldToLocalize.NonNullValue<System.String>()), result);
        else
            result.Add("TextFieldToLocalize", new [] { "TextFieldToLocalize is Required." });
    
        CollectValidationExceptions("NumberField", () => TestEntityLocalizationMetadata.CreateNumberField(this.NumberField), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TextFieldToLocalize { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int16 NumberField { get; set; } = default!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}