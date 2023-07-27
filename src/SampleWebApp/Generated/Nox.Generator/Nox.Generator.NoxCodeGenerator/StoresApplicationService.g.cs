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
public partial class StoresApplicationService : IStoreApplicationService
{
    public SampleWebAppDbContext DatabaseContext { get; }

    public StoresApplicationService(SampleWebAppDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    public virtual Store Create(StoreDto odataModel)
    {
        var entity = new Store();
        // TODO Setup Entity including Id
        DatabaseContext.Stores.Add(entity);
        return entity;
    }

    public virtual Store Update(StoreDto odataModel)
    {
        // TODO Fin Entity by id
        // TODO Setup Entity including Id
        throw new NotImplementedException();
    }
}

public interface IStoreApplicationService
{
    /// <summary>
    /// Creates an Store from a StoreDto
    /// </summary>
    Store Create(StoreDto odataModel);

    /// <summary>
    /// Updates an Store from a StoreDto
    /// </summary>
    Store Update(StoreDto odataModel);
}
