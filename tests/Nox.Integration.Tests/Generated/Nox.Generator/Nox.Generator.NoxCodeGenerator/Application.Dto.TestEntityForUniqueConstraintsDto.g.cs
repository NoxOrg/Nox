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
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Dto;

public record TestEntityForUniqueConstraintsKeyDto(System.String keyId);

public partial class TestEntityForUniqueConstraintsDto : TestEntityForUniqueConstraintsDtoBase
{

}

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class TestEntityForUniqueConstraintsDtoBase : EntityDtoBase, IEntityDto<TestEntityForUniqueConstraintsEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextField is not null)
            ExecuteActionAndCollectValidationExceptions("TextField", () => TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(this.TextField.NonNullValue<System.String>()), result);
        else
            result.Add("TextField", new [] { "TextField is Required." });
    
        ExecuteActionAndCollectValidationExceptions("NumberField", () => TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(this.NumberField), result);
    
        ExecuteActionAndCollectValidationExceptions("UniqueNumberField", () => TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(this.UniqueNumberField), result);
    
        if (this.UniqueCountryCode is not null)
            ExecuteActionAndCollectValidationExceptions("UniqueCountryCode", () => TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(this.UniqueCountryCode.NonNullValue<System.String>()), result);
        else
            result.Add("UniqueCountryCode", new [] { "UniqueCountryCode is Required." });
    
        if (this.UniqueCurrencyCode is not null)
            ExecuteActionAndCollectValidationExceptions("UniqueCurrencyCode", () => TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(this.UniqueCurrencyCode.NonNullValue<System.String>()), result);
        else
            result.Add("UniqueCurrencyCode", new [] { "UniqueCurrencyCode is Required." });
    

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
    public System.String TextField { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int16 NumberField { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int16 UniqueNumberField { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String UniqueCountryCode { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String UniqueCurrencyCode { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}