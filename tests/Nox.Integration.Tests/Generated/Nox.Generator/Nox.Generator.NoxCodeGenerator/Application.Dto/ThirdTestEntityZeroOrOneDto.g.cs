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

public record ThirdTestEntityZeroOrOneKeyDto(System.String keyId);

/// <summary>
/// Update ThirdTestEntityZeroOrOne
/// .
/// </summary>
public partial class ThirdTestEntityZeroOrOneDto : ThirdTestEntityZeroOrOneDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrOneDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.ThirdTestEntityZeroOrOne>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => DomainNamespace.ThirdTestEntityZeroOrOneMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
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
    /// ThirdTestEntityZeroOrOne Test entity relationship to ThirdTestEntityExactlyOne ZeroOrOne ThirdTestEntityExactlyOnes
    /// </summary>
    public virtual ThirdTestEntityExactlyOneDto? ThirdTestEntityExactlyOne { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}