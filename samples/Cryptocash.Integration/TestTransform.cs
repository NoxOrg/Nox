using CryptocashIntegration.Application.Integration.CustomTransform;

namespace Cryptocash.Integration;

public class TestTransform: TestTransformBase
{
    public override JsonToTableTargetDto Invoke(JsonToTableSourceDto source)
    {
        var result = base.Invoke(source);
        result.PopulationMillions = source.NoOfInhabitants / 1000000;
        return result;
    }
}