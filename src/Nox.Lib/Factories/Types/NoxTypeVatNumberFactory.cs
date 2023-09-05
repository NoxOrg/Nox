using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeVatNumberFactory : NoxTypeFactoryBase<VatNumber>
    {
        public NoxTypeVatNumberFactory(NoxSolution solution) : base(solution)
        {
        }

        public override VatNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return VatNumber.From(value.Number, value.CountryCode);
        }
    }
}