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

public record ForReferenceNumberKeyDto(System.String keyId);

/// <summary>
/// Update ForReferenceNumber
/// Entity created for testing auto number usages.
/// </summary>
public partial class ForReferenceNumberDto : ForReferenceNumberDtoBase
{

}

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public abstract class ForReferenceNumberDtoBase : EntityDtoBase
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.WorkplaceNumber is not null)
            ExecuteActionAndCollectValidationExceptions("WorkplaceNumber", () => DomainNamespace.ForReferenceNumberMetadata.CreateWorkplaceNumber(this.WorkplaceNumber.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Workplace Id
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Workplace Number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? WorkplaceNumber { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}