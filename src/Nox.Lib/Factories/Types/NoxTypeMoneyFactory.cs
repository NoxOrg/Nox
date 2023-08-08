using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeMoneyFactory : NoxTypeFactoryBase<Money>
    {
        public NoxTypeMoneyFactory(NoxSolution solution) : base(solution)
        {
        }
        
        public override Money? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Money.From(value.Amount, value.CurrencyCode, simpleTypeDefinition.MoneyTypeOptions ?? new MoneyTypeOptions());
        }
    }
}