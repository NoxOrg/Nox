using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeCurrencyCode3Factory : NoxTypeFactoryBase<CurrencyCode3>
    {
        public NoxTypeCurrencyCode3Factory(NoxSolution solution) : base(solution)
        {
        }

        public override CurrencyCode3? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
            => value is null ? null : CurrencyCode3.From(value);
    }
}
