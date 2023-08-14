using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeColorFactory : NoxTypeFactoryBase<Color>
    {
        public NoxTypeColorFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Color? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            switch (value)
            {
                case byte[] valueBytes:
                    return Color.From(valueBytes);
                case System.Drawing.Color valueColor:
                    return Color.From(valueColor);
                default:
                    return null;
            }
        }
    }
}