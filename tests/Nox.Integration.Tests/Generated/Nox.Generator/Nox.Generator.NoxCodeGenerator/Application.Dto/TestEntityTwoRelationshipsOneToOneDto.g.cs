// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public record TestEntityTwoRelationshipsOneToOneKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityTwoRelationshipsOneToOne
/// .
/// </summary>
public partial class TestEntityTwoRelationshipsOneToOneDto : TestEntityTwoRelationshipsOneToOneDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToOneDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.TestEntityTwoRelationshipsOneToOne>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField", () => DomainNamespace.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
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
    /// TestEntityTwoRelationshipsOneToOne First relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestRelationshipOneId { get; set; } = default!;
    public virtual SecondTestEntityTwoRelationshipsOneToOneDto? TestRelationshipOne { get; set; } = null!;

    /// <summary>
    /// TestEntityTwoRelationshipsOneToOne Second relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestRelationshipTwoId { get; set; } = default!;
    public virtual SecondTestEntityTwoRelationshipsOneToOneDto? TestRelationshipTwo { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}