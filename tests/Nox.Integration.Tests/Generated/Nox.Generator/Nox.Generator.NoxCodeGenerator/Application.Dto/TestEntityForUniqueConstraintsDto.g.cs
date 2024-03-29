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

public record TestEntityForUniqueConstraintsKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityForUniqueConstraints
/// Entity created for testing constraints.
/// </summary>
public partial class TestEntityForUniqueConstraintsDto : TestEntityForUniqueConstraintsDtoBase
{

}

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class TestEntityForUniqueConstraintsDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextField is not null)
            CollectValidationExceptions("TextField", () => TestEntityForUniqueConstraintsMetadata.CreateTextField(this.TextField.NonNullValue<System.String>()), result);
        else
            result.Add("TextField", new [] { "TextField is Required." });
    
        CollectValidationExceptions("NumberField", () => TestEntityForUniqueConstraintsMetadata.CreateNumberField(this.NumberField), result);
    
        CollectValidationExceptions("UniqueNumberField", () => TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(this.UniqueNumberField), result);
    
        if (this.UniqueCountryCode is not null)
            CollectValidationExceptions("UniqueCountryCode", () => TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(this.UniqueCountryCode.NonNullValue<System.String>()), result);
        else
            result.Add("UniqueCountryCode", new [] { "UniqueCountryCode is Required." });
    
        if (this.UniqueCurrencyCode is not null)
            CollectValidationExceptions("UniqueCurrencyCode", () => TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(this.UniqueCurrencyCode.NonNullValue<System.String>()), result);
        else
            result.Add("UniqueCurrencyCode", new [] { "UniqueCurrencyCode is Required." });
    

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
    public System.String TextField { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int16 NumberField { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int16 UniqueNumberField { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String UniqueCountryCode { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String UniqueCurrencyCode { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}