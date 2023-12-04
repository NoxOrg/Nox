using Nox.Solution;

namespace Nox.Lib.Presentation.Api.EndPointAddressBuilder;


public static class EndPointAddressBuilder
{
    public static IEndPointForService CreateBuilder(NoxSolution solution)
    {
        return new ServiceEndPointBuilder(solution);
    }
}

public interface IEndPointForService
{
    public IEndPointForEntity WithEntity(Entity entity);

    public string BuildUrl();
}

public interface IEndPointForEntity
{
    public IEndPointForEntityKey WithEntityKey<T>(T keyValue);
    public string BuildUrl();
}

public interface IEndPointForEntityKey
{
    public IEndPointForEntityKeyRelatedEntity WithRelatedEntity(Entity entity);
    public IEndPointForEntityKeyRelatedEntity WithRelatedEntity(string entityName);
    public string BuildUrl();
}
public interface IEndPointForEntityKeyRelatedEntity
{
    public IEndPointForEntityKeyRelatedEntity WithRefs();
    public string BuildUrl();
}
