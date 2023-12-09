using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Extensions;

public static class EntityExtensions
{
    public static IEnumerable<NoxTypeDatabaseConfiguration> GetLocalizedAttributesConfigurations(this Entity entity)
        => entity.GetLocalizedAttributes().Select(property =>
        {
            var configuration = property.ToNoxTypeDatabaseConfiguration();
            return configuration;
        });
}