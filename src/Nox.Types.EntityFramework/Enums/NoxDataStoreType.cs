namespace Nox.Types.EntityFramework.Enums;

/// <summary>
/// Data store type are used to flag a data provider for one or more storage types.
/// Only one data provider can have a specific flag set i.e. EntityStore, but one data provider can have multiple flags set.
/// For instance a data provider (sqlServer) can be flagged as the EntityStore where all the domain objects will be persisted, but another
/// data provider (postgres) can be flagged as the IntegrationStore.
/// If a data store is used but a specific implementation has not been specified in your solution.nox.yaml definition,
/// The Entity Store definition (infrastructure.persistence.databaseServer) will be used as the default.
/// </summary>
public enum NoxDataStoreType
{
    EntityStore,        //Persist domain entities as defined in the solution.nox.yaml
    JobStore,           //Persist Nox Hangfire job definitions
    MetaStore,          //Persist Nox solution metadata
    IntegrationStore    //Persist Nox integration specific data, like state information for each integration.
}