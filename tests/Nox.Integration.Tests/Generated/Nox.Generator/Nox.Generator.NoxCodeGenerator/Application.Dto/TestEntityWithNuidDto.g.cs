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

public record TestEntityWithNuidKeyDto(System.UInt32 keyId);

/// <summary>
/// Update TestEntityWithNuid
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuidDto : TestEntityWithNuidDtoBase
{

}

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public abstract class TestEntityWithNuidDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => TestEntityWithNuidMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}