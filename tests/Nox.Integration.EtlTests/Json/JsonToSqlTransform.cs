using Nox.Integration.Abstractions.Events;

namespace Nox.Integration.EtlTests.Json;

public class JsonToSqlTransform: JsonToSqlTransformHandlerBase<SourceDto>
{
    public JsonToSqlTransform()
    {
        TransformEvent += OnTransform;
    }

    private void OnTransform(object sender, NoxTransformEventArgs<SourceDto, TargetDto> args)
    {
        var source = args.Source;
        var target = args.Target;
        
        //Map the source to target
        target.Id = source.CountryId;
        target.Name = source.CountryName;
        target.Population = source.NoOfPeople;
        target.CreateDate = DateTime.Parse(source.DateCreated);
        target.EditDate = string.IsNullOrWhiteSpace(source.DateChanged) ? null : DateTime.Parse(source.DateChanged);
    }
}