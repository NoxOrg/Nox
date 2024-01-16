// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace TestWebApp.Application.Dto;

public record TestEntityOwnedRelationshipExactlyOneKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityOwnedRelationshipExactlyOne
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipExactlyOneDto : TestEntityOwnedRelationshipExactlyOneDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipExactlyOneDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            CollectValidationExceptions("TextTestField", () => TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField", new [] { "TextTestField is Required." });
    

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
    public System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecEntityOwnedRelExactlyOne ExactlyOne SecEntityOwnedRelExactlyOnes
    /// </summary>
    public virtual SecEntityOwnedRelExactlyOneDto SecEntityOwnedRelExactlyOne { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}