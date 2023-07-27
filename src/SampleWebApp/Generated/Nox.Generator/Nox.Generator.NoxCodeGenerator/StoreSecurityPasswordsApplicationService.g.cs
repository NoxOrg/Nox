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
public partial class StoreSecurityPasswordsApplicationService : IStoreSecurityPasswordsApplicationService
{
    public SampleWebAppDbContext DatabaseContext { get; }

    public StoreSecurityPasswordsApplicationService(SampleWebAppDbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    public virtual StoreSecurityPasswords Create(StoreSecurityPasswordsDto odataModel)
    {
        var entity = new StoreSecurityPasswords();
        // TODO Setup Entity including Id
        DatabaseContext.StoreSecurityPasswords.Add(entity);
        return entity;
    }

    public virtual StoreSecurityPasswords Update(StoreSecurityPasswordsDto odataModel)
    {
        // TODO Fin Entity by id
        // TODO Setup Entity including Id
        throw new NotImplementedException();
    }
}

public interface IStoreSecurityPasswordsApplicationService
{
    /// <summary>
    /// Creates an StoreSecurityPasswords from a StoreSecurityPasswordsDto
    /// </summary>
    StoreSecurityPasswords Create(StoreSecurityPasswordsDto odataModel);

    /// <summary>
    /// Updates an StoreSecurityPasswords from a StoreSecurityPasswordsDto
    /// </summary>
    StoreSecurityPasswords Update(StoreSecurityPasswordsDto odataModel);
}
