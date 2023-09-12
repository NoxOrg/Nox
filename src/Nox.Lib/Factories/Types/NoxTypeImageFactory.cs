using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeImageFactory : NoxTypeFactoryBase<Image>
{
    public NoxTypeImageFactory(NoxSolution solution) : base(solution)
    {
    }

    public override Image? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }
        return Image.From(value.Url, value.PrettyName, value.SizeInBytes, simpleTypeDefinition.ImageTypeOptions ?? new ImageTypeOptions());
    }
}