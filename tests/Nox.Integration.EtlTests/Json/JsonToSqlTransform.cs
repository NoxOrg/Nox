using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests.Json;

public class JsonToSqlTransform: JsonToSqlTransformBase, INoxTransform<SourceDto, TargetDto>
{
    public TargetDto Invoke(SourceDto source)
    {
        var result = new TargetDto();
        result.Id = source.CountryId;
        result.Name = source.CountryName;
        result.Population = source.NoOfPeople;
        result.CreateDate = DateTime.Parse(source.DateCreated);
        result.EditDate = string.IsNullOrWhiteSpace(source.DateChanged) ? null : DateTime.Parse(source.DateChanged);
        result.Etag = new Guid(source.ConcurrencyId);
        return result;
    }
}