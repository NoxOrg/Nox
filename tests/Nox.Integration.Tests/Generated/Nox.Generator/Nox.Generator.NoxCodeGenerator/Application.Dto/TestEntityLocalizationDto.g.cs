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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Dto;

public record TestEntityLocalizationKeyDto(System.String keyId);

public partial class TestEntityLocalizationDto : TestEntityLocalizationDtoBase
{

}

/// <summary>
/// Entity created for testing localization.
/// </summary>
public abstract class TestEntityLocalizationDtoBase : EntityDtoBase, IEntityDto<TestEntityLocalizationEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextFieldToLocalize is not null)
            ExecuteActionAndCollectValidationExceptions("TextFieldToLocalize", () => TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(this.TextFieldToLocalize.NonNullValue<System.String>()), result);
        else
            result.Add("TextFieldToLocalize", new [] { "TextFieldToLocalize is Required." });
    
        ExecuteActionAndCollectValidationExceptions("NumberField", () => TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(this.NumberField), result);
    

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
    public System.String TextFieldToLocalize { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int16 NumberField { get; set; } = default!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}