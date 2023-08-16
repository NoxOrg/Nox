using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeCultureCodeFactory : NoxTypeFactoryBase<CultureCode>
    {
        public NoxTypeCultureCodeFactory(NoxSolution solution) : base(solution)
        {
        }

        public override CultureCode? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
            => value is null ? null : CultureCode.From(value);
    }
}
