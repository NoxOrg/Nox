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
public partial class CountryLocalNamesApplicationService : ICountryLocalNamesApplicationService
{
    public SampleWebAppDbContext DatabaseContext { get; }

    public CountryLocalNamesApplicationService(SampleWebAppDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }
    public virtual CountryLocalNames Create(CountryLocalNamesDto odataModel)
    {
        var entity = new CountryLocalNames();
        // TODO Setup Entity including Id
        DatabaseContext.CountryLocalNames.Add(entity);
        return entity;
    }


    public virtual CountryLocalNames Update(CountryLocalNamesDto odataModel)
    {
        // TODO Fin Entity by id
        // TODO Setup Entity including Id
        throw new NotImplementedException();
    }
}

public interface ICountryLocalNamesApplicationService
{
    /// <summary>
    /// Creates an CountryLocalNames from a CountryLocalNamesDto
    /// </summary>
    CountryLocalNames Create(CountryLocalNamesDto odataModel);

    /// <summary>
    /// Updates an CountryLocalNames from a CountryLocalNamesDto
    /// </summary>
    CountryLocalNames Update(CountryLocalNamesDto odataModel);
}
