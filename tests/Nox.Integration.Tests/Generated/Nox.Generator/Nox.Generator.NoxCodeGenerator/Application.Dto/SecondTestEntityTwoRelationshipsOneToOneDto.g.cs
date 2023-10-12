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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Dto;

public record SecondTestEntityTwoRelationshipsOneToOneKeyDto(System.String keyId);

public partial class SecondTestEntityTwoRelationshipsOneToOneDto : SecondTestEntityTwoRelationshipsOneToOneDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToOneDtoBase : EntityDtoBase, IEntityDto<SecondTestEntityTwoRelationshipsOneToOneEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField2", new [] { "TextTestField2 is Required." });
    

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
    public System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToOneDto? TestRelationshipOneOnOtherSide { get; set; } = null!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToOneDto? TestRelationshipTwoOnOtherSide { get; set; } = null!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}