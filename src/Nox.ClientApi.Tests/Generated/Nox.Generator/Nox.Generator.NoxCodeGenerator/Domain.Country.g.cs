// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;
public partial class Country:CountryBase
{

}
/// <summary>
/// Country Entity.
/// </summary>
public abstract class CountryBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Population (Optional).
    /// </summary>
    public Nox.Types.Number? Population { get; set; } = null!;

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public Nox.Types.Money? CountryDebt { get; set; } = null!;

    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public Nox.Types.LanguageCode? FirstLanguageCode { get; set; } = null!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public string? ShortDescription
    { 
        get { return $"{Name} has a population of {Population} people."; }
        private set { }
    }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<Workplace> PhysicalWorkplaces { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalName> CountryShortNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
     public virtual CountryBarCode? CountryBarCode { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}