using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableTransform: JsonToTableTransformBase
{
    public override JsonToTableTargetDto Invoke(JsonToTableSourceDto source)
    {
        var result = base.Invoke(source);
        result.PopulationMillions = source.NoOfInhabitants / 1000000;
        return result;
    }
}
