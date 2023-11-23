// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public record TestEntityZeroOrOneToZeroOrManyKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityZeroOrOneToZeroOrMany
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOneToZeroOrManyDto : TestEntityZeroOrOneToZeroOrManyDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToZeroOrManyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.TestEntityZeroOrOneToZeroOrMany>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField", () => DomainNamespace.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
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
    /// TestEntityZeroOrOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToZeroOrOne ZeroOrOne TestEntityZeroOrManyToZeroOrOnes
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestEntityZeroOrManyToZeroOrOneId { get; set; } = default!;
    public virtual TestEntityZeroOrManyToZeroOrOneDto? TestEntityZeroOrManyToZeroOrOne { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}