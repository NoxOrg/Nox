namespace Nox.Integration.EtlTests.Json;

public abstract class JsonToSqlTransformBase
{
    public string IntegrationName => "JsonToSqlIntegration";
    public Type SourceType => typeof(SourceDto);
    public Type TargetType => typeof(TargetDto);
}

