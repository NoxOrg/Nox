// Generated

#nullable enable

using AutoMapper;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public abstract class JsonToTableTransformBase
{
    public string IntegrationName => "JsonToTable";

    public Type SourceType => typeof(JsonToTableSourceDto);

    public Type TargetType => typeof(JsonToTableTargetDto);
}