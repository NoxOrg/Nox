using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeVarNumberFactory : NoxTypeFactoryBase<VatNumber>
    {
        public NoxTypeVarNumberFactory(NoxSolution solution) : base(solution)
        {
        }

        public override VatNumber? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return VatNumber.From(value.Number, value.CountryCode2);
        }
    }
}