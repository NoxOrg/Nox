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

public record TestEntityExactlyOneToZeroOrOneKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityExactlyOneToZeroOrOne
/// .
/// </summary>
public partial class TestEntityExactlyOneToZeroOrOneDto : TestEntityExactlyOneToZeroOrOneDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrOneDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.TestEntityExactlyOneToZeroOrOne>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => DomainNamespace.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
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
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestEntityZeroOrOneToExactlyOneId { get; set; } = default!;
    public virtual TestEntityZeroOrOneToExactlyOneDto? TestEntityZeroOrOneToExactlyOne { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}