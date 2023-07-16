namespace Nox.Integration.Constants;

public static class IntegrationExecutorConstants
{
    public const string DefaultMergeProperty = "EtlBox.ChangeDate";
    public static readonly DateTime MinSqlDate = new DateTime(1753, 01, 01, 0, 0, 0);
    public const string MergeSchemaName = "Integration";
    public const string MergeStateTableName = "MergeState";
}