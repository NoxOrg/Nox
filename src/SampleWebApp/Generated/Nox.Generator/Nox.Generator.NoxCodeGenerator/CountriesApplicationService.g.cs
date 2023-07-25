// Generated

#nullable enable

using System;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;


namespace SampleWebApp.Application;

/// <summary>
/// ....
/// </summary>
public partial class CountriesApplicationService : ICountryApplicationService
{
    public SampleWebAppDbContext DatabaseContext { get; }

    public CountriesApplicationService(SampleWebAppDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }
    public virtual Country Create(CountryDto odataModel)
    {
        var entity = new Country();
        // TODO Setup Entity including Id
        DatabaseContext.Countries.Add(entity);
        return entity;
    }


    public virtual Country Update(CountryDto odataModel)
    {
        // TODO Fin Entity by id
        // TODO Setup Entity including Id
        throw new NotImplementedException();
    }
}

public interface ICountryApplicationService
{
    /// <summary>
    /// Creates an Country from a CountryDto
    /// </summary>
    Country Create(CountryDto odataModel);

    /// <summary>
    /// Updates an Country from a CountryDto
    /// </summary>
    Country Update(CountryDto odataModel);
}
