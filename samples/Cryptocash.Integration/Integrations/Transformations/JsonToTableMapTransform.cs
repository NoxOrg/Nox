using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableMapTransform: JsonToTableMapTransformBase, INoxCustomTransform
{
    public override JsonToTableMapTargetDto InvokeBase(JsonToTableMapSourceDto sourceRecord)
    {
        return base.InvokeBase(sourceRecord);
    }
}