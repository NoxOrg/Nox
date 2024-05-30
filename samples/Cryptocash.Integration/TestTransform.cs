using CryptocashIntegration.Application.Integration.CustomTransform;

namespace Cryptocash.Integration;

public class TestTransform: TestTransformBase
{
    public override JsonToTableTargetDto Invoke(JsonToTableSourceDto source)
    {
        var result = base.Invoke(source);
        result.PopulationMillions = source.NoOfInhabitants / 1000000;
        
        //DateOnly to DateTime
        var dateOnly = new DateOnly(2024, 5, 29);
        var doToDt = dateOnly.ToDateTime(new TimeOnly(0, 0));
        
        var dateTime = DateTime.Now;
        //DateTime to DateOnly
        var dtToDo = DateOnly.FromDateTime(dateTime);
        //DateTime to TimeOnly
        var dtToTo = TimeOnly.FromDateTime(dateTime);
        
        
        
        return result;
        
    }
}