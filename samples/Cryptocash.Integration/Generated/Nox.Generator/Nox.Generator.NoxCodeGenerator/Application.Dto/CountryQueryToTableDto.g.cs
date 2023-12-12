// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = CryptocashIntegration.Domain;

namespace CryptocashIntegration.Application.Dto;

public record CountryQueryToTableKeyDto(System.Int32 keyId);

/// <summary>
/// Update CountryQueryToTable
/// Country and related data.
/// </summary>
public partial class CountryQueryToTableDto : CountryQueryToTableDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryQueryToTableDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.CountryQueryToTable>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.CountryQueryToTableMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        ExecuteActionAndCollectValidationExceptions("Population", () => DomainNamespace.CountryQueryToTableMetadata.CreatePopulation(this.Population), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country unique identifier
    /// </summary>    
    public System.Int32 Id { get; set; } = default!;

    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 Population { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}