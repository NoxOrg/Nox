// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using TestWebApp.Domain;
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Dto;

public record ThirdTestEntityExactlyOneKeyDto(System.String keyId);

public partial class ThirdTestEntityExactlyOneDto : ThirdTestEntityExactlyOneDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class ThirdTestEntityExactlyOneDtoBase : EntityDtoBase, IEntityDto<ThirdTestEntityExactlyOneEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField", () => TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField", new [] { "TextTestField is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// ThirdTestEntityExactlyOne Test entity relationship to ThirdTestEntityZeroOrOne ExactlyOne ThirdTestEntityZeroOrOnes
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? ThirdTestEntityZeroOrOneRelationshipId { get; set; } = default!;
    public virtual ThirdTestEntityZeroOrOneDto? ThirdTestEntityZeroOrOneRelationship { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}