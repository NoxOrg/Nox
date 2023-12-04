using Nox.Solution;

namespace Nox.Lib.Presentation.Api.EndPointAddressBuilder;

internal sealed class EntityEndPointBuilder : IEndPointForEntity, IEndPointForEntityKey, IEndPointForEntityKeyRelatedEntity
{
    private readonly ServiceEndPointBuilder _endPointAddress;
    private string? _withKeyValue;
    private Entity? _withRelatedEntity;
    private bool? _withRef;
    

    public EntityEndPointBuilder(ServiceEndPointBuilder endPointAddress)
    {
        _endPointAddress = endPointAddress;
    }

    public string BuildUrl()
    {
        if (_withKeyValue is null)
        {
            return $"{_endPointAddress.BuildUrl()}";
        }
        if (_withRelatedEntity is null)
        {
            return $"{_endPointAddress.BuildUrl()}/{_withKeyValue}";
        }
        if (_withRef is null)
        {
            //TODO Type of Relationship single or multiple?
            return $"{_endPointAddress.BuildUrl()}/{_withKeyValue}/{_withRelatedEntity.PluralName}";
        }
        //TODO Type of Relationship single or multiple?
        return $"{_endPointAddress.BuildUrl()}/{_withKeyValue}/{_withRelatedEntity.PluralName}/$ref";
    }

    public IEndPointForEntityKey WithEntityKey<T>(T keyValue)
    {
        ArgumentNullException.ThrowIfNull(keyValue);

        _withKeyValue = keyValue.ToString();
        return this;
    }

    public IEndPointForEntityKeyRelatedEntity WithRefs()
    {
        _withRef = true;
        return this;

    }

    public IEndPointForEntityKeyRelatedEntity WithRelatedEntity(Entity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _withRelatedEntity = entity;
        return this;
    }

    public IEndPointForEntityKeyRelatedEntity WithRelatedEntity(string entityName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(entityName);

        _withRelatedEntity = _endPointAddress.Solution.Domain!.GetEntityByName(entityName);
        return this;
    }
}