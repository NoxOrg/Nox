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

public record SecondTestEntityTwoRelationshipsOneToManyKeyDto(System.String keyId);

/// <summary>
/// Update SecondTestEntityTwoRelationshipsOneToMany
/// .
/// </summary>
public partial class SecondTestEntityTwoRelationshipsOneToManyDto : SecondTestEntityTwoRelationshipsOneToManyDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToManyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityTwoRelationshipsOneToMany>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => DomainNamespace.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
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
    /// SecondTestEntityTwoRelationshipsOneToMany First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestRelationshipOneOnOtherSideId { get; set; } = default!;
    public virtual TestEntityTwoRelationshipsOneToManyDto? TestRelationshipOneOnOtherSide { get; set; } = null!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToMany Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestRelationshipTwoOnOtherSideId { get; set; } = default!;
    public virtual TestEntityTwoRelationshipsOneToManyDto? TestRelationshipTwoOnOtherSide { get; set; } = null!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}