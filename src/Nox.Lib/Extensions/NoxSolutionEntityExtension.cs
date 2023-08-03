using Nox.Types;

namespace Nox.Extensions
{
    public static class NoxSolutionEntityExtension
    {
        public static Text CreateText(this Nox.Solution.Entity entityDefinition, string propertyName, string value)
        {           
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return Text.From(value, attributeDefinition.TextTypeOptions ?? new TextTypeOptions());
        }
    }
}
