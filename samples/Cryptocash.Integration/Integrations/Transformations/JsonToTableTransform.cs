using CryptocashIntegration.Application.Integration.CustomTransform;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableTransform: JsonToTableTransformBase
{
    public override JsonToTableTargetDto Invoke(JsonToTableSourceDto source)
    {
        var result = base.Invoke(source);
        if (source.NoOfInhabitants.HasValue)
        {
            result.PopulationMillions = (int)source.NoOfInhabitants / 1000000;
        }

        result.NameWithConcurrency = source.CountryName + "_" + source.ConcurrencyStamp;
        return result;
    }
}