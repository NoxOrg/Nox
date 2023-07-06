// Generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleWebApp.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application;

/// <summary>
/// Returns a list of countries for a given continent.
/// </summary>
public abstract partial class GetCountriesByContinentQuery
{
    
    /// <summary>
    /// Represents the DB context.
    /// </summary>
    protected readonly SampleWebAppDbContext _dbContext;
    
    public GetCountriesByContinentQuery(
        SampleWebAppDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }
    public abstract Task<IEnumerable<CountryInfo>> ExecuteAsync(Text continentName);
}
