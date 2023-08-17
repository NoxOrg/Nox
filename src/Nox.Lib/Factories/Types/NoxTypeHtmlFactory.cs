using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeHtmlFactory : NoxTypeFactoryBase<Nox.Types.Html>
    {
        public NoxTypeHtmlFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.Html? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Nox.Types.Html.From(value);
        }
    }
}