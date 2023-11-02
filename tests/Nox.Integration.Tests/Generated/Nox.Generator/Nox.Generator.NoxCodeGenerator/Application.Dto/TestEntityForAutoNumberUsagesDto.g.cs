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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Dto;

public record TestEntityForAutoNumberUsagesKeyDto(System.Int64 keyId);

public partial class TestEntityForAutoNumberUsagesDto : TestEntityForAutoNumberUsagesDtoBase
{

}

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public abstract class TestEntityForAutoNumberUsagesDtoBase : EntityDtoBase, IEntityDto<TestEntityForAutoNumberUsagesEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        ExecuteActionAndCollectValidationExceptions("AutoNumberField", () => TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberField(this.AutoNumberField), result);
    
        if (this.TextField is not null)
            ExecuteActionAndCollectValidationExceptions("TextField", () => TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(this.TextField.NonNullValue<System.String>()), result);
        else
            result.Add("TextField", new [] { "TextField is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int64 AutoNumberField { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}