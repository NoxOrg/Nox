namespace Nox.Types.EntityFramework.Enums;

public enum NoxDataStoreType
{
    EntityStore,        //Persists domain entities as defined in the solution.nox.yaml                              }
    JobStore,           //Persist Nox Hangfire job definitions                                                      |     All These default to the Entity Store if not specified
    MetaStore,          //Persists Nox solution metadata                                                            |
    IntegrationStore    //Persists Nox integration specific data, like state information for each integration.      }
}