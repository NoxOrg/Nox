using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeMoneyFactory : NoxTypeFactoryBase<Money>
    {
        public NoxTypeMoneyFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Money? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return Money.From(value.Amount, value.CurrencyCode, attributeDefinition.MoneyTypeOptions ?? new MoneyTypeOptions());
        }
    }
}