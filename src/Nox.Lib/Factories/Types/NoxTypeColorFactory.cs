using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeColorFactory : NoxTypeFactoryBase<Color>
{
    public NoxTypeColorFactory(NoxSolution solution) : base(solution)
    {
    }

    public override Color? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }
        return Color.From((string)value);
    }
}