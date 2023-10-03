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

namespace TestWebApp.Application.Dto;

public record TestEntityZeroOrOneToOneOrManyKeyDto(System.String keyId);

public partial class TestEntityZeroOrOneToOneOrManyDto : TestEntityZeroOrOneToOneOrManyDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToOneOrManyDtoBase : EntityDtoBase, IEntityDto<TestEntityZeroOrOneToOneOrMany>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField", () => TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
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
    /// TestEntityZeroOrOneToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrOne ZeroOrOne TestEntityOneOrManyToZeroOrOnes
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? TestEntityOneOrManyToZeroOrOneId { get; set; } = default!;
    public virtual TestEntityOneOrManyToZeroOrOneDto? TestEntityOneOrManyToZeroOrOne { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}