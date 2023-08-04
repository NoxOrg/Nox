using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeNumberFactory : NoxTypeFactoryBase<Number>
    {
        public NoxTypeNumberFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Number? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {            
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return Number.From(value, attributeDefinition.NumberTypeOptions ?? new NumberTypeOptions());
        }
    }
}