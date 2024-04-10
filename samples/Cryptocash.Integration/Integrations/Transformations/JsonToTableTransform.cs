using AutoMapper;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Events;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableTransform: JsonToTableTransformBase<JsonToTableSourceDto>
{
    public JsonToTableTransform()
    {
        TransformEvent += OnTransform;
    }

    private void OnTransform(object sender, NoxTransformEventArgs<JsonToTableSourceDto, JsonToTableTargetDto> args)
    {
        var source = args.Source;
        var target = args.Target;
        
        //Map the source to target
        target.Id = source.CountryId;
        target.Name = source.CountryName;
        target.Population = source.NoOfInhabitants;
        target.CreateDate = DateTime.Parse(source.DateCreated);
        target.EditDate = string.IsNullOrWhiteSpace(source.DateChanged) ? null : DateTime.Parse(source.DateChanged);
        target.Etag = new Guid(source.ConcurrencyStamp);
    }
    
}
