using Nox.Solution;

namespace Nox.Lib.Presentation.Api.EndPointAddressBuilder;

internal class ServiceEndPointBuilder : IEndPointForService
{
    public readonly NoxSolution Solution;

    public Entity Entity { get; private set; } = null!;
    public ServiceEndPointBuilder(NoxSolution solution)
    {
        Solution = solution;
    }

    public IEndPointForEntity WithEntity(Entity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        Entity = entity;
        return new EntityEndPointBuilder(this);
    }

    public string BuildUrl()
    {
        return $"{Solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{Entity.PluralName}";
    }
}
