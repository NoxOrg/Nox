using Microsoft.EntityFrameworkCore;

namespace Nox.Types.EntityFramework.Configurations
{
    public class NoxTypeRelationshipConfiguration
    {
        public bool ConfigureToManyRelationship { get; }
        public bool ConfigureNavigationProperty { get; }
        public string? ReversedNavigationPropertyName { get; }
        public DeleteBehavior DeleteBehavior { get; }

        public NoxTypeRelationshipConfiguration(
            bool configureToManyRelationship,
            bool configureNavigationProperty = true,
            string? reversedNavigationPropertyName = null,
            DeleteBehavior deleteBehavior = DeleteBehavior.NoAction)
        {
            ConfigureNavigationProperty = configureNavigationProperty;
            ConfigureToManyRelationship = configureToManyRelationship;
            ReversedNavigationPropertyName = reversedNavigationPropertyName;
            DeleteBehavior = deleteBehavior;
        }
    }
}
