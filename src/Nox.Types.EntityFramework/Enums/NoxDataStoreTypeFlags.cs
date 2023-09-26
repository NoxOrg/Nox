namespace Nox.Types.EntityFramework.Enums;

[Flags]
public enum NoxDataStoreTypeFlags
{
    EntityStore,        //Persists domain entities as defined in the solution.nox.yaml                             --
    JobStore,           //Persist Nox Hangfire job definitions                                                      |     These default to the Entity Store if not specified explicitly
    MetaStore,          //Persists Nox solution metadata                                                            |
    IntegrationStore    //Persists Nox integration specific data, like state information for each integration.     --
}