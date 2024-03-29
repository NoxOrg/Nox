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

public record TestEntityForAutoNumberUsagesKeyDto(System.Int64 keyId);

/// <summary>
/// Update TestEntityForAutoNumberUsages
/// Entity created for testing auto number usages.
/// </summary>
public partial class TestEntityForAutoNumberUsagesDto : TestEntityForAutoNumberUsagesDtoBase
{

}

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public abstract class TestEntityForAutoNumberUsagesDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        CollectValidationExceptions("AutoNumberFieldWithOptions", () => TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberFieldWithOptions(this.AutoNumberFieldWithOptions), result);
    
        CollectValidationExceptions("AutoNumberFieldWithoutOptions", () => TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberFieldWithoutOptions(this.AutoNumberFieldWithoutOptions), result);
    
        if (this.TextField is not null)
            CollectValidationExceptions("TextField", () => TestEntityForAutoNumberUsagesMetadata.CreateTextField(this.TextField.NonNullValue<System.String>()), result);
        else
            result.Add("TextField", new [] { "TextField is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int64 AutoNumberFieldWithOptions { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int64 AutoNumberFieldWithoutOptions { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TextField { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}