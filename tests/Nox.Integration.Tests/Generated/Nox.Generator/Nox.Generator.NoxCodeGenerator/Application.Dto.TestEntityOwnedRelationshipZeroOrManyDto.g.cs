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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Dto;

public record TestEntityOwnedRelationshipZeroOrManyKeyDto(System.String keyId);

public partial class TestEntityOwnedRelationshipZeroOrManyDto : TestEntityOwnedRelationshipZeroOrManyDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipZeroOrManyDtoBase : EntityDtoBase, IEntityDto<TestEntityOwnedRelationshipZeroOrManyEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField", () => TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
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
    /// TestEntityOwnedRelationshipZeroOrMany Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrMany ZeroOrMany SecondTestEntityOwnedRelationshipZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipZeroOrManyDto> SecondTestEntityOwnedRelationshipZeroOrMany { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}