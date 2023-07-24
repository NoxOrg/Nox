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
public partial class CurrenciesApplicationService : ICurrencyApplicationService
{
    public SampleWebAppDbContext DatabaseContext { get; }

    public CurrenciesApplicationService(SampleWebAppDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }
    public virtual Currency Create(CurrencyDto odataModel)
    {
        var entity = new Currency();
        // TODO Setup Entity including Id
        DatabaseContext.Currencies.Add(entity);
        return entity;
    }


    public virtual Currency Update(CurrencyDto odataModel)
    {
        // TODO Fin Entity by id
        // TODO Setup Entity including Id
        throw new NotImplementedException();
    }
}

public interface ICurrencyApplicationService
{
    /// <summary>
    /// Creates an Currency from a CurrencyDto
    /// </summary>
    Currency Create(CurrencyDto odataModel);

    /// <summary>
    /// Updates an Currency from a CurrencyDto
    /// </summary>
    Currency Update(CurrencyDto odataModel);
}
